using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetAll();
        Blog Get(int id);
        void Create(Blog entity);
        void Update(Blog entity);
        void Delete(int id);
    }
}
