using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using OpenSourceBlog.Core.Interfaces;
using OpenSourceBlog.Core.Models;
using OpenSourceBlog.Infrastructure.Context;

namespace OpenSourceBlog.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        //ToDo UserRepository using userManager
        private readonly UserContext ctx = new UserContext();
        public IEnumerable<AspNetUser> GetAll()
        {
            return ctx.AspNetUsers.ToList();
        }

        public AspNetUser Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Create(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public void Update(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
