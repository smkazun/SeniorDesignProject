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
        IEnumerable<AspNetUser> GetAll();
        AspNetUser Get(string id);
        void Create(AspNetUser user);
        void Update(AspNetUser user);
        void Delete(string id);
    }
}
