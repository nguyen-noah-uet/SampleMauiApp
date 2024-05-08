using Microsoft.EntityFrameworkCore;
using SampleMauiApp.Domain;
using SampleMauiApp.EFCore.Repositories;
using SampleMauiApp.EFCore.Services;

namespace SampleMauiApp.Biz.Services
{
    public class ProductGroupAppService : EfCoreAppService<ProductGroup>, IProductGroupAppService
    {
        private readonly IProductGroupRepository repository;

        public ProductGroupAppService(IProductGroupRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public override Task<List<ProductGroup>> GetAllAsync(bool includeDetail = false)
        {
            if (!includeDetail)
                return base.GetAllAsync(includeDetail);
            else
            {
                IQueryable<ProductGroup> query = repository.GetQueryable().Include(p => p.Products);
                return query.ToListAsync();
            }
        }
    }
}
