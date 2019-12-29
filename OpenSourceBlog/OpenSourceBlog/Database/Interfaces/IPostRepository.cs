using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        Post Get(int id);
        void Create(Post entity);
        void Update(Post entity);
        void Delete(int id);
    }
}
