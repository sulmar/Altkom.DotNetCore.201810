using Altkom.DotNetCore.IServices;
using Altkom.DotNetCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.DotNetCore.FakeServices
{
    // Klasa generyczna
    public abstract class FakeEntitiesService<TEntity> : IEntitiesService<TEntity>
        where TEntity : Base
    {
        protected IList<TEntity> entities;

        public virtual void Add(TEntity entity) => entities.Add(entity);
        public virtual IList<TEntity> Get() => entities;
        public virtual TEntity Get(int id) => entities.SingleOrDefault(e => e.Id == id);

        public virtual void Remove(int id)
        {
            TEntity entity = Get(id);
            entities.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
