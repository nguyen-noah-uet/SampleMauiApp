using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SampleMauiApp.Biz.Services;
using SampleMauiApp.Domain;
using SampleMauiApp.Domain.Extensions;
using SampleMauiApp.Views;
using SampleMauiApp.Views.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;

namespace SampleMauiApp.ViewModels
{
    public partial class ProductListViewModel : BaseViewModel
    {
        private readonly IProductGroupAppService productGroupAppService;
        private readonly IProductAppService productAppService;
        [ObservableProperty]
        private ObservableCollection<ProductGroup> productGroups = new();
        public ProductListViewModel(IProductGroupAppService productGroupAppService, IProductAppService productAppService)
        {
            Title = "Product List";
            this.productGroupAppService = productGroupAppService;
            this.productAppService = productAppService;
            
            var timer = new System.Timers.Timer(50) { AutoReset = false };
            timer.Elapsed += async (s, e) =>
            {
                IsBusy = true;
                await LoadData();
                IsBusy = false;
            };
            timer.Start();
        }

        private async Task LoadData()
        {
            //await Task.Delay(400);
            ProductGroups.Clear();
            var groups = await productGroupAppService.GetAllAsync(includeDetail: true);
            foreach (var group in groups)
            {
                ProductGroups.Add(group);
                //OnPropertyChanged(nameof(group.Products.Count));
            }
        }

        [RelayCommand]
        private async Task AddProductGroup()
        {
            await Shell.Current.GoToAsync(nameof(AddProductGroupPage));
        }

        [RelayCommand]
        private async Task EditProductGroup(ProductGroup pg)
        {
            await Shell.Current.GoToAsync(nameof(EditProductGroupPage), new Dictionary<string,object>() { { "ProductGroup", pg} });
        }

        [RelayCommand]
        private async Task DeleteProductGroup(ProductGroup pg)
        {
            // Show confirmation dialog
            var result = await Shell.Current.DisplayAlert("Delete Product Group", $"Are you sure you want to delete {pg.Name}?", "Yes", "No");
            if (result)
            {
                IsBusy = true;
                await productGroupAppService.Delete(pg.Id);
                IsBusy = false;
                await Shell.Current.GoToAsync($"{nameof(ProductListViewPage)}");
            }
        }

        [RelayCommand]
        private async Task AddProduct()
        {
            await Shell.Current.GoToAsync(nameof(AddProductPage));
        }

        [RelayCommand]
        private async Task EditProduct(Product p)
        {
            await Shell.Current.GoToAsync(nameof(EditProductPage), new Dictionary<string,object>() { { "Product", p} });
        }

        [RelayCommand]
        private async Task DeleteProduct(Product p)
        {
            // Show confirmation dialog
            var result = await Shell.Current.DisplayAlert("Delete Product", $"Are you sure you want to delete {p.Name}?", "Yes", "No");
            if (result)
            {
                IsBusy = true;
                await productAppService.Delete(p.Id);
                
                //await Shell.Current.GoToAsync($"{nameof(ProductListViewPage)}");
                await LoadData();
                IsBusy = false;

            }

        }


    }
}
