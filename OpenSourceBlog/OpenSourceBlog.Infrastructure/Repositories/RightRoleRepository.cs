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
    public class RightRoleRepository : IRepository<RightRole, int>
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

        public void Update(int id, RightRole entityNew)
        {
            //ToDo Update and change the old data to new data
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            RightRole rr = Get(id);
            ctx.RightRoles.Remove(rr);
            ctx.SaveChanges();
        }
    }
}
