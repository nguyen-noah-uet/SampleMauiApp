using SampleMauiApp.Domain;
using SampleMauiApp.EFCore.Repositories;

namespace SampleMauiApp.EFCore.DataSeeder
{
    public class AppDataSeeder : IDataSeeder
    {
        private readonly IProductRepository productRepository;
        private readonly IProductGroupRepository productGroupRepository;

        public AppDataSeeder(IProductRepository productRepository, IProductGroupRepository productGroupRepository)
        {
            this.productRepository = productRepository;
            this.productGroupRepository = productGroupRepository;
        }
        public async Task SeedDataAsync()
        {
            if(productRepository.Count() > 0 || productGroupRepository.Count() > 0)
            {
                return;
            }
            var productGroup = new ProductGroup
            {
                Name = "Group 1"
            };
            await productGroupRepository.Create(productGroup);
            var product = new Product
            {
                Name = "Product 1",
                Description = "Product 1 Description",
                Price = 100,
                ProductGroupId = productGroup.Id
            };
            await productRepository.Create(product);

            product = new Product
            {
                Name = "Product 2",
                Description = "Product 2 Description",
                Price = 200,
                ProductGroupId = productGroup.Id
            };
            await productRepository.Create(product);

            var productGroup2 = new ProductGroup
            {
                Name = "Group 2"
            };
            await productGroupRepository.Create(productGroup2);

            var productGroup3 = new ProductGroup
            {
                Name = "Group 3"
            };
            await productGroupRepository.Create(productGroup3);

            product = new Product
            {
                Name = "Product 3",
                Description = "Product 3 Description",
                Price = 300,
                ProductGroupId = productGroup3.Id
            };
            await productRepository.Create(product);
            product = new Product
            {
                Name = "Product 4",
                Description = "Product 4 Description",
                Price = 400,
                ProductGroupId = productGroup3.Id
            };
            await productRepository.Create(product);


        }
    }
}
