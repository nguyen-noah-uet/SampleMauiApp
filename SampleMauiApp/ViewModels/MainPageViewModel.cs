using CommunityToolkit.Mvvm.Input;
using SampleMauiApp.Views.Views;

namespace SampleMauiApp.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {

        public MainPageViewModel()
        {
            Title = "Main Page";
        }
        [RelayCommand]
        private async Task GoToProductList()
        {
            await Shell.Current.GoToAsync(nameof(ProductListViewPage));
        }
    }
}
