using System;
using System.Collections.Generic;
using OpenSourceBlog.Core.Interfaces;
using OpenSourceBlog.Core.Models;
using OpenSourceBlog.Infrastructure.Context;

using System.Configuration;
using System.Linq;


namespace OpenSourceBlog.Infrastructure.Repositories
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

        public void Update(int id, Blog entityNew)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Blog b = Get(id);
            ctx.Blogs.Remove(b);
            ctx.SaveChanges();
        }
    }
}
