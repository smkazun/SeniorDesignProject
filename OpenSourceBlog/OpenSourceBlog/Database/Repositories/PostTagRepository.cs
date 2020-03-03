using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Repositories
{
    public class PostTagRepository : IGenericRepository<PostTag, int>
    {
        private readonly ApplicationContext ctx = new ApplicationContext();
        public IEnumerable<PostTag> GetAll()
        {
            return ctx.PostTags.ToList();
        }

        public PostTag Get(int id)
        {
            return ctx.PostTags.Find(id);
        }

        public void Create(PostTag entity)
        {
            ctx.PostTags.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(PostTag entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            PostTag pt = Get(id);
            ctx.PostTags.Remove(pt);
            ctx.SaveChanges();
        }
    }
}
