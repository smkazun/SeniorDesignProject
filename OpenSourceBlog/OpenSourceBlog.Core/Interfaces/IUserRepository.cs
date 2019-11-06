using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Core.Models;

namespace OpenSourceBlog.Core.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(string id);
        void Create(User user);
        void Update(User user);
        void Delete(string id);
    }
}
