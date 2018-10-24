using Altkom.DotNetCore.IServices;
using Altkom.DotNetCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.DotNetCore.FakeServices
{
    // Klasa generyczna
    public abstract class FakeEntitiesService<TEntity> : IEntitiesService<TEntity>
        where TEntity : Base
    {
        protected IList<TEntity> entities;

        public virtual void Add(TEntity entity) => entities.Add(entity);

        public Task AddAsync(TEntity entity)
        {
            return Task.Run(() => Add(entity));
        }

        public virtual IList<TEntity> Get() => entities;
        public virtual TEntity Get(int id) => entities.SingleOrDefault(e => e.Id == id);

        public Task<IList<TEntity>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Remove(int id)
        {
            TEntity entity = Get(id);
            entities.Remove(entity);
        }

        public Task RemoveAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
