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
    public class PostCommentRepository : IRepository<PostComment, int>
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
