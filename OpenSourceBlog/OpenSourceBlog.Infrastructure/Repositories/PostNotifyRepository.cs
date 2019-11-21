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

        public void Update(PostNotify entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            PostNotify pn = Get(id);
            ctx.PostNotifies.Remove(pn);
            ctx.SaveChanges();
        }
    }
}
