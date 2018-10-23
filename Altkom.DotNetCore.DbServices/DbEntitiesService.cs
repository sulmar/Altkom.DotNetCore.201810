using Altkom.DotNetCore.IServices;
using Altkom.DotNetCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.DotNetCore.DbServices
{
    public class DbEntitiesService<TEntity> : IEntitiesService<TEntity>
        where TEntity : Base, new()
    {
        protected readonly MyContext context;

        public DbEntitiesService(MyContext context)
        {
            this.context = context;
        }

        public virtual void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public virtual IList<TEntity> Get()
        {
            IQueryable<TEntity> entities = context.Set<TEntity>();

            // entities = entities.Where(e => e.Id > 0).ToList().AsQueryable();

            var list = entities.ToList();

            return list;
        }

        public virtual TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual void Remove(int id)
        {
            // TEntity entity = Get(id);
            TEntity entity = new TEntity();
            entity.Id = id;

            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
    }
}
