
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SampleMauiApp.Biz.Services;
using SampleMauiApp.Domain;
using SampleMauiApp.Views;
using SampleMauiApp.Views.Views;

namespace SampleMauiApp.ViewModels
{
    public partial class EditProductGroupViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly IProductGroupAppService productGroupAppService;
        [ObservableProperty]
        private ProductGroup? productGroup;
        public EditProductGroupViewModel(IProductGroupAppService productGroupAppService)
        {
            Title = "Edit Product Group";
            this.productGroupAppService = productGroupAppService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            ProductGroup = query["ProductGroup"] as ProductGroup;
            Title = $"Edit {ProductGroup?.Name}";
        }
        [RelayCommand]
        private async Task Save()
        {
            if (ProductGroup == null)
            {
                return;
            }
            // Save the product group
            await productGroupAppService.Update(ProductGroup.Id, ProductGroup);
            await Shell.Current.DisplayAlert(Title, "Product Group saved", "OK");
            await Shell.Current.GoToAsync(nameof(ProductListViewPage));

        }
        [RelayCommand]
        private async Task Cancel()
        {
            await Shell.Current.GoToAsync(nameof(ProductListViewPage));
        }
        [RelayCommand]
        private async Task AddProduct()
        {
            if (ProductGroup == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(AddProductPage)}", new Dictionary<string, object>() { { "ProductGroupId", ProductGroup.Id } });
        }
    }
}
