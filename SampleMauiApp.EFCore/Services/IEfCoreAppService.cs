using SampleMauiApp.Domain;

namespace SampleMauiApp.EFCore.Services
{
    public interface IEfCoreAppService<TEntity> where TEntity : BaseModel
    {
        Task<List<TEntity>> GetAllAsync(bool includeDetail = false);
        Task<IQueryable<TEntity>> GetQueryable();
        Task<TEntity?> GetById(Guid id);
        Task Create(TEntity entity);
        Task Update(Guid id, TEntity entity);
        Task Delete(Guid id);
        long Count();
    }
}
