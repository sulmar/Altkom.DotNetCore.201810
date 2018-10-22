using System.Collections.Generic;

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
    }

}
