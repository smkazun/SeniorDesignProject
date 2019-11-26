using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Repositories
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

        public void Update(Post entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Post p = Get(id);
            ctx.Posts.Remove(p);
            ctx.SaveChanges();
        }
    }
}