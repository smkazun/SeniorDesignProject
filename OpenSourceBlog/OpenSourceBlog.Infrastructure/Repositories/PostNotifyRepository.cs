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
    public class PostNotifyRepository : IRepository<PostNotify, int>
    {
        private readonly ApplicationContext ctx = new ApplicationContext();

        public IEnumerable<PostNotify> GetAll()
        {
            return ctx.PostNotifies.ToList();
        }

        public PostNotify Get(int id)
        {
            return ctx.PostNotifies.Find(id);
        }

        public void Create(PostNotify entity)
        {
            ctx.PostNotifies.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(int id, PostNotify entityNew)
        {
            //ToDo Update and change the old data to new data
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            PostNotify pn = Get(id);
            ctx.PostNotifies.Remove(pn);
            ctx.SaveChanges();
        }
    }
}
