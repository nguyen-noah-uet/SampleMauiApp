using SampleMauiApp.Domain;
using SampleMauiApp.EFCore.Services;

namespace SampleMauiApp.Biz.Services
{
    public interface IProductAppService : IEfCoreAppService<Product>
    {
    }
}
