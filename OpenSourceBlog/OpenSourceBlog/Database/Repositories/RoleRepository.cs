using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Repositories
{
    public class RoleRepository : IRepository<AspNetRole, string>
    {
        private readonly ApplicationContext ctx = new ApplicationContext();

        public IEnumerable<AspNetRole> GetAll()
        {
            return ctx.AspNetRoles.ToList();
        }

        public AspNetRole Get(string id)
        {
            return ctx.AspNetRoles.Find(id);
        }

        public void Create(AspNetRole entity)
        {
            ctx.AspNetRoles.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(AspNetRole entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(string id)
        {
            AspNetRole r = Get(id);
            ctx.AspNetRoles.Remove(r);
            ctx.SaveChanges();
        }
    }
}
