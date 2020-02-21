using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IRightRoleRepository
    {
        IEnumerable<RightRole> GetAll();
        RightRole Get(int id);
        void Create(RightRole entity);
        void Update(RightRole entity);
        void Delete(int id);
    }
}
