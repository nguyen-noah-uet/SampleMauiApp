using SampleMauiApp.ViewModels;

namespace SampleMauiApp.Views
{
    public partial class AddProductPage : ContentPage
    {
        public AddProductPage(AddProductViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
        public AddProductPage()
        {
            InitializeComponent();
        }
    }
}
