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
    public class StopWordRepository : IRepository<StopWord, int>
    {
        private readonly ApplicationContext ctx = new ApplicationContext();

        public IEnumerable<StopWord> GetAll()
        {
            return ctx.StopWords.ToList();
        }

        public StopWord Get(int id)
        {
            return ctx.StopWords.Find(id);
        }

        public void Create(StopWord entity)
        {
            ctx.StopWords.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(StopWord entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            StopWord sw = Get(id);
            ctx.StopWords.Remove(sw);
            ctx.SaveChanges();
        }
    }
}
