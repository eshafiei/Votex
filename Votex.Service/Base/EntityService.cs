using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Votex.Model.Base;
using Votex.Service.Interface;

namespace Votex.Service.Base
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        protected IContext Context;
        protected IDbSet<T> Dbset;

        public EntityService(IContext context)
        {
            Context = context;
            Dbset = Context.Set<T>();
        }


        public virtual bool Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            Dbset.Add(entity);
            Context.SaveChanges();
            return true;
        }


        public virtual bool Update(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException("entity");
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return true;
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            Dbset.Remove(entity);
            Context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Dbset.AsEnumerable<T>();
        }
    }
}
