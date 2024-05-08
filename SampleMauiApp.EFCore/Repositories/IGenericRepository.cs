using SampleMauiApp.Domain;

namespace SampleMauiApp.EFCore.Repositories
{
    public interface IGenericRepository<TModel> where TModel : BaseModel
    {
        IQueryable<TModel> GetQueryable();

        Task<TModel?> GetById(Guid id);

        Task Create(TModel entity);

        Task Update(Guid id, TModel entity);

        Task Delete(Guid id);

        long Count();
    }
}
