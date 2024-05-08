using Microsoft.EntityFrameworkCore;
using SampleMauiApp.Domain;
using SampleMauiApp.EFCore.Repositories;
using SampleMauiApp.EFCore.Services;

namespace SampleMauiApp.Biz.Services
{
    public class ProductAppService : EfCoreAppService<Product>, IProductAppService
    {
        private readonly IProductRepository repository;

        public ProductAppService(IProductRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public override Task<List<Product>> GetAllAsync(bool includeDetail = false)
        {
            return base.GetAllAsync(includeDetail);
            //if (!includeDetail)
            //    return base.GetAllAsync(includeDetail);
            //else
            //{
            //    IQueryable<Product> query = repository.GetQueryable().Include(p => p.ProductGroup);
            //    return query.ToListAsync();
            //}
        }
    }
}
