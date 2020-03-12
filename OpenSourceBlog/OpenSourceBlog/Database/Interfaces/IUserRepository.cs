using System.Collections.Generic;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IUserRepository
    {
  
        AspNetRole GetRole(string id);
        AspNetRole GetRoleByUserName(string username);
    }
}
