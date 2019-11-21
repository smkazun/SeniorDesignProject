using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Core.Interfaces;
using OpenSourceBlog.Core.Models;

namespace OpenSourceBlog.Infrastructure.Repositories
{
    public class UserRoleRepository : IRepository<AspNetUserRole, string>
    {
        private readonly  ApplicationContext ctx = new ApplicationContext();

        public IEnumerable<AspNetUserRole> GetAll()
        {
            return ctx.AspNetUserRoles.ToList();
        }

        public AspNetUserRole Get(string id)
        {
            return ctx.AspNetUserRoles.Find(id);
        }

        public void Create(AspNetUserRole entity)
        {
            ctx.AspNetUserRoles.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(AspNetUserRole entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            AspNetUserRole ur = Get(id);
            ctx.AspNetUserRoles.Remove(ur);
            ctx.SaveChanges();
        }
    }
}
