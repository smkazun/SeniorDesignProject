using System;
using System.Collections.Generic;
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

        public void Update(int id, StopWord entityNew)
        {
            //ToDo Update and change the old data to new data
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            StopWord sw = Get(id);
            ctx.StopWords.Remove(sw);
            ctx.SaveChanges();
        }
    }
}
