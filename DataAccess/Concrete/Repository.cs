using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        public void Add(TEntity entity)
        {
            using(Context context=new Context())
            {
                var addedEntity=context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (Context context = new Context())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {   
            using (Context context=new Context())
            {
                return context.Set<TEntity>().ToList();
            }
            
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            using (Context context = new Context())
           {
             return context.Set<TEntity>().SingleOrDefault(filter);
         }
        }

        //public TEntity GetById(int id)
        //{
        //    using (Context context = new Context())
        //    {
        //        return context.Set<TEntity>().SingleOrDefault(id);
        //    }
        //}

        public TEntity GetId(TEntity entity)
        {
            using (Context context = new Context())
            {
                return context.Set<TEntity>().Find(entity);
            }
        }

        public void Update(TEntity entity)
        {
            using (Context context = new Context())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
