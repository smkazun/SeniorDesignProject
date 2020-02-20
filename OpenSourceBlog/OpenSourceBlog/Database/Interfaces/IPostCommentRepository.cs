using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IPostCommentRepository
    {
        IEnumerable<PostComment> GetAll();
        PostComment Get(int id);
        void Create(PostComment entity);
        void Update(PostComment entity);
        void Delete(int id);
    }
}
