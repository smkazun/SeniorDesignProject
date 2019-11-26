using System.Collections.Generic;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
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
