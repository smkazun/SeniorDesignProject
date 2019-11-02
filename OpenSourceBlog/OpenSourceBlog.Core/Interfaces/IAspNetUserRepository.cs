using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.OpenSourceBlog.Core.Models;

namespace OpenSourceBlog.Core.Interfaces
{
    public interface IAspNetUserRepository
    {
        IEnumerable<AspNetUser> SelectAll();
        AspNetUser SelectByUserName(string username);
        void Insert(AspNetUser user);
        void Update(AspNetUser user);
        void Delete(string username);
        void Save();
    }
}
