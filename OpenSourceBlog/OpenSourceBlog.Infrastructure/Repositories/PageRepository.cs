using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Core.Interfaces;
using OpenSourceBlog.Core.Models;

namespace OpenSourceBlog.Infrastructure.Repositories
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

        public void Update(int id, Page entityNew)
        {
            //ToDo Update and change
        }

        public void Delete(int id)
        {
            Page p = Get(id);
            ctx.Pages.Remove(p);
            ctx.SaveChanges();
        }
    }
}
