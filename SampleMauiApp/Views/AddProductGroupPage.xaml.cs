using SampleMauiApp.ViewModels;

namespace SampleMauiApp.Views
{
    public partial class AddProductGroupPage : ContentPage
    {
        public AddProductGroupPage()
        {
            InitializeComponent();
        }
        public AddProductGroupPage(AddProductGroupViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
