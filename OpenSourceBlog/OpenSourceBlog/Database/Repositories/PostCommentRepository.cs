using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Repositories
{
    public class PostCommentRepository : IPostCommentRepository
    {
        private readonly ApplicationContext ctx = new ApplicationContext();
        public IEnumerable<PostComment> GetAll()
        {
            return ctx.PostComments.ToList();
        }

        public PostComment Get(int id)
        {
            return ctx.PostComments.Find(id);
        }

        public void Create(PostComment entity)
        {
            ctx.PostComments.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(PostComment entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            PostComment pc = Get(id);
            ctx.PostComments.Remove(pc);
            ctx.SaveChanges();
        }
    }
}
