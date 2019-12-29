using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IUserRoleRepository
    {
        IEnumerable<AspNetUserRole> GetAll();
        AspNetUserRole Get(string id);
        void Create(AspNetUserRole entity);
        void Update(AspNetUserRole entity);
        void Delete(string id);
    }
}
