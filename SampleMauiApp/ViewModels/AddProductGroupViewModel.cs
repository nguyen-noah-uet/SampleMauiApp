using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SampleMauiApp.Biz.Services;
using SampleMauiApp.Domain;
using SampleMauiApp.Views.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMauiApp.ViewModels
{
    public partial class AddProductGroupViewModel : BaseViewModel
    {
        private readonly IProductGroupAppService productGroupAppService;
        [ObservableProperty]
        private ProductGroup productGroup = new ProductGroup();
        public AddProductGroupViewModel(IProductGroupAppService productGroupAppService)
        {
            Title = "Add Product Group";
            this.productGroupAppService = productGroupAppService;
        }
        [RelayCommand]
        private async Task Save()
        {
            await productGroupAppService.Create(ProductGroup);
            await Shell.Current.DisplayAlert(Title, "Product Group added", "OK");
            await Shell.Current.GoToAsync($"{nameof(ProductListViewPage)}");
        }
        [RelayCommand]
        private async Task Cancel()
        {
            await Shell.Current.GoToAsync($"{nameof(ProductListViewPage)}");
        }
        
    }
}
