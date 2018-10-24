using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altkom.DotNetCore.IServices
{
    // interfejs generyczny (szablon)
    public interface IEntitiesService<TEntity>
    {
        IList<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);

        Task<IList<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(int id);
    }

}
