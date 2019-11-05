using System.Collections.Generic;
using System.Linq;
using OpenSourceBlog.Core.Interfaces;
using OpenSourceBlog.Core.Models;
using OpenSourceBlog.Infrastructure.Context;

namespace OpenSourceBlog.Infrastructure.Repositories
{
    public class CategoryRepository : IRepository<Category, int>
    {
        private readonly CategoryContext ctx = new CategoryContext();

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

        public void Update(int id, Category entityNew)
        {
            //ToDo Update and change the old data to new data
        }

        public void Delete(int id)
        {
            Category c = Get(id);
            ctx.Categories.Remove(c);
            ctx.SaveChanges();
        }
    }
}
