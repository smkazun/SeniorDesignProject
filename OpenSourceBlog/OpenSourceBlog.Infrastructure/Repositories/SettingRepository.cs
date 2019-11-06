using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Core.Interfaces;
using OpenSourceBlog.Core.Models;

namespace OpenSourceBlog.Infrastructure.Repositories
{
    public class SettingRepository : IRepository<Setting, int>
    {
        private readonly ApplicationContext ctx = new ApplicationContext();

        public IEnumerable<Setting> GetAll()
        {
            return ctx.Settings.ToList();
        }

        public Setting Get(int id)
        {
            return ctx.Settings.Find(id);
        }

        public void Create(Setting entity)
        {
            ctx.Settings.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(int id, Setting entityNew)
        {
            //ToDo Update and change the old data to new data
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Setting s = Get(id);
            ctx.Settings.Remove(s);
            ctx.SaveChanges();
        }
    }
}
