using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleMauiApp.Biz.Services;
using SampleMauiApp.EFCore;
using SampleMauiApp.EFCore.DataSeeder;
using SampleMauiApp.EFCore.Repositories;
using SampleMauiApp.ViewModels;
using SampleMauiApp.Views;
using SampleMauiApp.Views.Views;
namespace SampleMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                #if ANDROID
                var dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "sample.db");
                options.UseSqlite($"Filename={dbPath}");
#elif IOS
                options.UseSqlite($"Data Source={System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sample.db")}");
#elif WINDOWS
                options.UseSqlite($"Data Source=sample.db");
#endif
            });
            builder.Services.AddSingleton<AppShell>();

            // ViewModels
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<ProductListViewModel>();
            builder.Services.AddTransient<AddProductGroupViewModel>();
            builder.Services.AddTransient<EditProductGroupViewModel>();
            builder.Services.AddTransient<AddProductViewModel>();
            builder.Services.AddTransient<EditProductViewModel>();

            // Views
            builder.Services.AddTransient<MainPage>(p=> new MainPage() { BindingContext = p.GetRequiredService<MainPageViewModel>() });
            builder.Services.AddTransient<ProductListViewPage>(p => new ProductListViewPage() { BindingContext = p.GetRequiredService<ProductListViewModel>() });
            builder.Services.AddTransient<AddProductGroupPage>(p => new AddProductGroupPage() { BindingContext = p.GetRequiredService<AddProductGroupViewModel>() });
            builder.Services.AddTransient<EditProductGroupPage>(p => new EditProductGroupPage() { BindingContext = p.GetRequiredService<EditProductGroupViewModel>() });
            builder.Services.AddTransient<AddProductPage>(p => new AddProductPage() { BindingContext = p.GetRequiredService<AddProductViewModel>() });
            builder.Services.AddTransient<EditProductPage>(p => new EditProductPage() { BindingContext = p.GetRequiredService<EditProductViewModel>() });


            // Repositories
            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<IProductGroupRepository, ProductGroupRepository>();
            // DataSeed
            builder.Services.AddTransient<IDataSeeder, AppDataSeeder>();
            // Services
            builder.Services.AddTransient<IProductAppService, ProductAppService>();
            builder.Services.AddTransient<IProductGroupAppService, ProductGroupAppService>();



#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();
            using var dbContext = app.Services.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
            var dataSeeder = app.Services.GetRequiredService<IDataSeeder>();
            dataSeeder.SeedDataAsync().Wait();

            return app;
        }
    }

}
