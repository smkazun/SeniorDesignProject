using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;


namespace OpenSourceBlog.Database.Repositories
{
    public class BlogRepository : IRepository<Blog, int>
    {
        private readonly ApplicationContext ctx = new ApplicationContext();

        public IEnumerable<Blog> GetAll()
        {
            return ctx.Blogs.ToList();
        }

        public Blog Get(int id)
        {
            return ctx.Blogs.Find(id);
        }

        public void Create(Blog entity)
        {
            ctx.Blogs.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(Blog entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Blog b = Get(id);
            ctx.Blogs.Remove(b);
            ctx.SaveChanges();
        }
    }
}
