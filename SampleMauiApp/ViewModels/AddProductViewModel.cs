
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SampleMauiApp.Biz.Services;
using SampleMauiApp.Domain;
using SampleMauiApp.Views.Views;
using System.Collections.ObjectModel;
using System.Linq;

namespace SampleMauiApp.ViewModels
{
    public partial class AddProductViewModel : BaseViewModel,IQueryAttributable
    {
        private readonly IProductAppService productAppService;
        private readonly IProductGroupAppService productGroupAppService;
        [ObservableProperty]
        private Guid productGroupId;

        [ObservableProperty]
        private Product product = new Product();

        [ObservableProperty]
        private List<ProductGroup> productGroups = new();

        [ObservableProperty]
        private ProductGroup? selectedProductGroup;

        public AddProductViewModel(IProductAppService productAppService, IProductGroupAppService productGroupAppService)
        {
            Title = "Add Product";
            this.productAppService = productAppService;
            this.productGroupAppService = productGroupAppService;
            ProductGroups = this.productGroupAppService.GetAllAsync().Result;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            SelectedProductGroup = ProductGroups.FirstOrDefault();
            if (query.ContainsKey("ProductGroupId"))
            {
                ProductGroupId = (Guid)query["ProductGroupId"];
                if (ProductGroupId != Guid.Empty)
                {
                    SelectedProductGroup = ProductGroups.FirstOrDefault(x => x.Id == ProductGroupId);
                }
            }
        }
        [RelayCommand]
        private async Task Save()
        {
            Product.ProductGroupId = SelectedProductGroup.Id;
            await productAppService.Create(Product);
            await Shell.Current.DisplayAlert(Title, "Product added", "OK");
            await Shell.Current.GoToAsync($"{nameof(ProductListViewPage)}");
        }
        [RelayCommand]
        private async Task Cancel()
        {
            await Shell.Current.GoToAsync($"{nameof(ProductListViewPage)}");
        }
    }
}
