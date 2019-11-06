using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Core.Interfaces;
using OpenSourceBlog.Core.Models;
using OpenSourceBlog.Infrastructure.Context;

namespace OpenSourceBlog.Infrastructure.Repositories
{
    public class UserRepository : IRepository<User, string>
    {
        //ToDo UserRepository using userManager
        private readonly UserContext ctx = new UserContext();
        public IEnumerable<User> GetAll()
        {
            //ToDo
            throw new NotImplementedException();
        }

        public User Get(string id)
        {
            //ToDo
            throw new NotImplementedException();
        }
        public void Create(User entity)
        {
            //ToDo
            throw new NotImplementedException();
        }
        public void Update(string id, User entityNew)
        {
            //ToDo
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            //ToDo
            throw new NotImplementedException();
        }
    }
}
