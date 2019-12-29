using System;
using System.Collections.Generic;
using System.Linq;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
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
