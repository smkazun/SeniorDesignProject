using System;
using System.Collections.Generic;
using System.Linq;
using OpenSourceBlog.Core.Interfaces;
using OpenSourceBlog.Core.Models;

namespace OpenSourceBlog.Infrastructure.Repositories
{
    public class PostRepository : IRepository<Post, int>
    {
        private readonly ApplicationContext ctx = new ApplicationContext();

        public IEnumerable<Post> GetAll()
        {
            return ctx.Posts.ToList();
        }

        public Post Get(int id)
        {
            return ctx.Posts.Find(id);
        }

        public void Create(Post entity)
        {
            ctx.Posts.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(int id, Post entityNew)
        {
            //ToDo Update and change the old data to new data
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Post p = Get(id);
            ctx.Posts.Remove(p);
            ctx.SaveChanges();
        }
    }
}