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
    public class UserRepository : IUserRepository
    {
        UserContext context = new UserContext();
        public Task<List<object>> SelectAll()
        {
            return context.Users.ToListAsync();
        }

        public Task<object> SelectByUserName(string username)
        {
            return context.Users.FindAsync(username);
        }

        public void Insert(User user)
        {
            context.Users.Add(user);
        }

        public void Update(User user)
        {
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(string username)
        {
            //ToDo Delete properly from database
        }

        public void Save()
        {
            
        }
    }
}
