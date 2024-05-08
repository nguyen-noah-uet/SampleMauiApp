using SampleMauiApp.Views;
using SampleMauiApp.Views.Views;

namespace SampleMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ProductListViewPage), typeof(ProductListViewPage));
            Routing.RegisterRoute(nameof(EditProductGroupPage), typeof(EditProductGroupPage));
            Routing.RegisterRoute(nameof(AddProductGroupPage), typeof(AddProductGroupPage));
            Routing.RegisterRoute(nameof(AddProductPage), typeof(AddProductPage));
            Routing.RegisterRoute(nameof(EditProductPage), typeof(EditProductPage));



        }
    }
}
