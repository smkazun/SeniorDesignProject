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
    public class CategoryRepository : IRepository<Category, string>
    {
        private readonly CategoryContext context = new CategoryContext();

        public IEnumerable<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category Get(string id)
        {
            //ToDo string or int?
            return context.Categories.Find(id);
        }

        public void Create(Category entity)
        {
            context.Categories.Add(entity);
            context.SaveChanges();
        }

        public void Update(string id, Category entityNew)
        {
            //ToDo Update and change the old data to new data
        }

        public void Delete(string id)
        {
            //ToDo string or int?
            Category c = Get(id);
            context.Categories.Remove(c);
            context.SaveChanges();
        }
    }
}
