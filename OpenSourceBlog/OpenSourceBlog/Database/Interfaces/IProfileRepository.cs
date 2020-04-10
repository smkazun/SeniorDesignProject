using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IProfileRepository : IGenericRepository<Profile, int>
    {
        //IEnumerable<Profile> GetAll();
        //Profile Get(int id);
        //void Create(Profile entity);
        //void Update(Profile entity);
        //void Delete(int id);
    }
}
