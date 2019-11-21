using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Core.Interfaces;
using OpenSourceBlog.Core.Models;

namespace OpenSourceBlog.Infrastructure.Repositories
{
    public class RightRepository : IRepository<Right, int>
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
