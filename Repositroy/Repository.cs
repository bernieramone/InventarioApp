using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repositroy
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity GetEntity(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            
        }
    }
}
