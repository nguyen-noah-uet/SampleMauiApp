
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SampleMauiApp.Domain;
using SampleMauiApp.Views.Views;

namespace SampleMauiApp.ViewModels
{
    public partial class EditProductViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        private Product? product;
        public EditProductViewModel()
        {
            Title = "Edit Product";
            
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Product = query["Product"] as Product;
            Title = $"Edit {Product?.Name}";
            
        }
        [RelayCommand]
        private async Task Save()
        {
            if (Product == null)
            {
                return;
            }
            // Save the product
            await Shell.Current.DisplayAlert(Title, "Product saved", "OK");
            await Shell.Current.GoToAsync(nameof(ProductListViewPage));
        }
        [RelayCommand]
        private async Task Cancel()
        {
            await Shell.Current.GoToAsync(nameof(ProductListViewPage));
        }
    }
}
