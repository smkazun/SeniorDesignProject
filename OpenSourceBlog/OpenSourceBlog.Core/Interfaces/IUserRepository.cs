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
        Task<List<object>> SelectAll();
        Task<object> SelectByUserName(string username);
        void Insert(User user);
        void Update(User user);
        void Delete(string username);
        void Save();
    }
}
