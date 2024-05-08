using Microsoft.EntityFrameworkCore;
using SampleMauiApp.Domain;
using SampleMauiApp.EFCore.Repositories;

namespace SampleMauiApp.EFCore.Services
{
    public class EfCoreAppService<TEntity> : IEfCoreAppService<TEntity> where TEntity : BaseModel
    {
        private readonly IGenericRepository<TEntity> _repository;

        public EfCoreAppService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity?> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(TEntity entity)
        {
            await _repository.Create(entity);
        }

        public async Task Update(Guid id, TEntity entity)
        {
            await _repository.Update(id, entity);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public long Count()
        {
            return _repository.Count();
        }

        public virtual async Task<List<TEntity>> GetAllAsync(bool includeDetail = false)
        {
            return await _repository.GetQueryable().ToListAsync();
        }

        public Task<IQueryable<TEntity>> GetQueryable()
        {
            return Task.FromResult(_repository.GetQueryable());
        }
    }
}
