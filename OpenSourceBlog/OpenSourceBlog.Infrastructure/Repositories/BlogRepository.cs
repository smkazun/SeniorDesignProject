using System;
using System.Collections.Generic;
using OpenSourceBlog.Core.Interfaces;
using OpenSourceBlog.Core.Models;
using OpenSourceBlog.Infrastructure.Context;

using System.Configuration;
using System.Linq;


namespace OpenSourceBlog.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private BlogContext context = new BlogContext();

        public void Create(Blog b)
        {
            context.Blogs.Add(b);
            context.SaveChanges();
        }

        public void Update(Blog b)
        {
            context.Entry(b).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int Id)
        {
            Blog b = (Blog) context.Blogs.Find(Id);
            context.Blogs.Remove(b);
            context.SaveChanges();
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return context.Blogs.ToList();
        }

        public Blog GetByRowId(int Id)
        {
            return context.Blogs.Find(Id);
        }
    }
}
