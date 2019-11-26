using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Repositories
{
    public class PageRepository : IRepository<Page, int>
    {
        private readonly ApplicationContext ctx = new ApplicationContext();
        public IEnumerable<Page> GetAll()
        {
            return ctx.Pages.ToList();
        }

        public Page Get(int id)
        {
            return ctx.Pages.Find(id);
        }

        public void Create(Page entity)
        {
            ctx.Pages.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(Page entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Page p = Get(id);
            ctx.Pages.Remove(p);
            ctx.SaveChanges();
        }
    }
}
