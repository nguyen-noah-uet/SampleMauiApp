using SampleMauiApp.Domain;
using SampleMauiApp.EFCore.Services;

namespace SampleMauiApp.Biz.Services
{
    public interface IProductGroupAppService : IEfCoreAppService<ProductGroup>
    {
    }
}
