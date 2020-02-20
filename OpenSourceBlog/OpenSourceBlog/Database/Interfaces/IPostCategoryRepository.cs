using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IPostCategoryRepository
    {
        IEnumerable<PostCategory> GetAll();
        PostCategory Get(int id);
        void Create(PostCategory entity);
        void Update(PostCategory entity);
        void Delete(int id);
    }
}
