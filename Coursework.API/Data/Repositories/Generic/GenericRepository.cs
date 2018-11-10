using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        public ApplicationDBContext context;
        public DbSet<TEntity> Set => this.context.Set<TEntity>();

        public GenericRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Set.RemoveRange(entities);
        }

        public async Task<TEntity> GetAsync(string id)
        {
            return await Set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Set.ToListAsync();
        }

        public Task AddAsync(TEntity entity)
        {
            return Set.AddAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return Set.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            Set.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Set.UpdateRange(entities);
        }
    }
}
