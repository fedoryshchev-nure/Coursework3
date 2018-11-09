using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Generic
{
    public interface IGenericRepository<TEntity>
    {
        Task<TEntity> GetAsync(string id);
        Task<IEnumerable<TEntity>> GetAll();

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entity);

        //void Update(TEntity entity);
        //void UpdateRange(IEnumerable<TEntity> entity);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entity);
    }
}
