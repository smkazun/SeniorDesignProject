using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.DAL;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Repositories
{
    public class GenericRepository<T, U> : IGenericRepository<T,U> where T :class
                                                                   where U :IConvertible
    {
        protected readonly ApplicationContext _ctx;

        public GenericRepository()
        {
            this._ctx = new ApplicationContext();
        }

        public GenericRepository(ApplicationContext context)
        {
            this._ctx = context;
        }



        public IEnumerable<T> GetAll()
        {
           
            return _ctx.Set<T>().ToList();
           // return _ctx.ToList();
        }

        public T Get(U id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            _ctx.Set<T>().Add(entity);
           // _ctx.SaveChanges();
        }

        public void Update(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            
            // _ctx.SaveChanges();
        }

        public void Delete(U id)
        {
            T existing = Get(id);
            _ctx.Set<T>().Remove(existing);
           // _ctx.SaveChanges();
        }

        //TODO: move
        /*
        public IEnumerable<Setting> GetSettings()
        {
            //AsNoTracking()
            return _ctx.Settings.Where(x => x.BlogId == GlobalVars.BlogId).ToList();
        }*/

    }
}