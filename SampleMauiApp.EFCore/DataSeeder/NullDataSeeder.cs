namespace SampleMauiApp.EFCore.DataSeeder
{
    public class NullDataSeeder : IDataSeeder
    {
        public Task SeedDataAsync()
        {
            return Task.CompletedTask;
        }
    }
}
