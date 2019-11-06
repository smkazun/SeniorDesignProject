using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Core.Interfaces;
using OpenSourceBlog.Core.Models;
using OpenSourceBlog.Infrastructure.Context;

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

        public void Update(int id, PostComment entityNew)
        {
            //ToDo Update and change the old data to new data
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            PostComment pc = Get(id);
            ctx.PostComments.Remove(pc);
            ctx.SaveChanges();
        }
    }
}
