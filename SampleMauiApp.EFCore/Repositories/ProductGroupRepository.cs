using SampleMauiApp.Domain;

namespace SampleMauiApp.EFCore.Repositories
{
    public class ProductGroupRepository : GenericRepository<ProductGroup>, IProductGroupRepository
    {
        public ProductGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
