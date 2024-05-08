using Microsoft.EntityFrameworkCore;
using SampleMauiApp.Domain;

namespace SampleMauiApp.EFCore.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : BaseModel
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public long Count()
        {
            return _dbContext.Set<TEntity>().LongCount();
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity?> GetById(Guid id)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(Guid id, TEntity entity)
        {
            var existingEntity = await GetById(id);
            if (existingEntity == null)
            {
                throw new Exception("Entity not found");
            }
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
