using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IPostTagRepository
    {
        IEnumerable<PostTag> GetAll();
        PostTag Get(int id);
        void Create(PostTag entity);
        void Update(PostTag entity);
        void Delete(int id);
    }
}
