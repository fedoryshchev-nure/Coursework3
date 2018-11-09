using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        public ApplicationDBContext context;
        public DbSet<TEntity> set => this.context.Set<TEntity>();

        public GenericRepository(ApplicationDBContext context)
        {
            this.context = context;
            // set = context.Set<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            set.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            set.RemoveRange(entities);
        }

        public async Task<TEntity> GetAsync(string id)
        {
            return await set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await set.ToListAsync();
        }

        public Task AddAsync(TEntity entity)
        {
            return set.AddAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return set.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            set.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            set.UpdateRange(entities);
        }
    }
}
