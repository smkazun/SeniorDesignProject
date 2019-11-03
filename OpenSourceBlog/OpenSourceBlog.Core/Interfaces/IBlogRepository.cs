using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Core.Models;

namespace OpenSourceBlog.Core.Interfaces
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetBlogs();
        Blog GetByRowId(int Id);
        void Create(Blog b);
        void Update(Blog b);
        void Delete(int Id);
    }
}
