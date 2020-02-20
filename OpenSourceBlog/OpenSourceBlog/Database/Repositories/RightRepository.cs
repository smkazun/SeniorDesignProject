using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Repositories
{
    public class RightRepository : IRightRepository
    {
        private readonly ApplicationContext ctx = new ApplicationContext();
        public IEnumerable<Right> GetAll()
        {
            return ctx.Rights.ToList();
        }

        public Right Get(int id)
        {
            return ctx.Rights.Find(id);
        }

        public void Create(Right entity)
        {
            ctx.Rights.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(Right entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Right r = Get(id);
            ctx.Rights.Remove(r);
            ctx.SaveChanges();
        }
    }
}
