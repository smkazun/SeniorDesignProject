using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Repositories
{
    public class RightRoleRepository : IRightRoleRepository
    {
        private readonly ApplicationContext ctx = new ApplicationContext();

        public IEnumerable<RightRole> GetAll()
        {
            return ctx.RightRoles.ToList();
        }

        public RightRole Get(int id)
        {
            return ctx.RightRoles.Find(id);
        }

        public void Create(RightRole entity)
        {
            ctx.RightRoles.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(RightRole entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            RightRole rr = Get(id);
            ctx.RightRoles.Remove(rr);
            ctx.SaveChanges();
        }
    }
}
