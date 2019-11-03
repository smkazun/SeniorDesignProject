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
    public class UserRepository : IUserRepository
    {
        private UserContext context = new UserContext();
        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public Task<User> GetByUserName(string username)
        {
            return context.Users.FindAsync(username);
        }

        public void Create(User user)
        {
            //ToDo Create a user properly, but should already been done through Identity
        }

        public void Update(User user)
        {
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(string username)
        {
            //ToDo Delete properly from database
        }
    }
}
