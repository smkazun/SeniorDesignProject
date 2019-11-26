using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Repositories
{
    public class CategoryRepository : IRepository<Category, int>
    {
        private readonly ApplicationContext ctx = new ApplicationContext();

        public IEnumerable<Category> GetAll()
        {
            return ctx.Categories.ToList();
        }

        public Category Get(int id)
        {
            return ctx.Categories.Find(id);
        }

        public void Create(Category entity)
        {
            ctx.Categories.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(Category entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Category c = Get(id);
            ctx.Categories.Remove(c);
            ctx.SaveChanges();
        }
    }
}
