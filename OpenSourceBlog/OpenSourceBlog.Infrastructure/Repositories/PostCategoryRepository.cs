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
    public class PostCategoryRepository : IRepository<PostCategory, int>
    {
        private readonly ApplicationContext ctx = new ApplicationContext();
        public IEnumerable<PostCategory> GetAll()
        {
            return ctx.PostCategories.ToList();
        }

        public PostCategory Get(int id)
        {
            return ctx.PostCategories.Find(id);
        }

        public void Create(PostCategory entity)
        {
            ctx.PostCategories.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(PostCategory entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            PostCategory pc = Get(id);
            ctx.PostCategories.Remove(pc);
            ctx.SaveChanges();
        }
    }
}
