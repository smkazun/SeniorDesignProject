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
    public class ProfileRepository : IRepository<Profile, int>
    {
        private readonly ApplicationContext ctx = new ApplicationContext();
        public IEnumerable<Profile> GetAll()
        {
            return ctx.Profiles.ToList();
        }

        public Profile Get(int id)
        {
            return ctx.Profiles.Find(id);
        }

        public void Create(Profile entity)
        {
            ctx.Profiles.Add(entity);
        }

        public void Update(Profile entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Profile p = Get(id);
            ctx.Profiles.Remove(p);
            ctx.SaveChanges();
        }
    }
}
