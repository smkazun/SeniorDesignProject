using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<AspNetRole> GetAll();
        AspNetRole Get(string id);
        void Create(AspNetRole entity);
        void Update(AspNetRole entity);
        void Delete(string id);
    }
}
