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
        AspNetUser FindByUserName(string username);
        AspNetRole GetRole(string id);
        AspNetRole GetRoleByUserName(string username);
    }
}
