using Altkom.DotNetCore.IServices;
using Altkom.DotNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public virtual async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
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

        public virtual async Task<IList<TEntity>> GetAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public virtual void Remove(int id)
        {
            // TEntity entity = Get(id);
            TEntity entity = new TEntity();
            entity.Id = id;

            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public virtual async Task RemoveAsync(int id)
        {
            TEntity entity = new TEntity();
            entity.Id = id;

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
