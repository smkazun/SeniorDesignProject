using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IPostNotifyRepository
    {
        IEnumerable<PostNotify> GetAll();
        PostNotify Get(int id);
        void Create(PostNotify entity);
        void Update(PostNotify entity);
        void Delete(int id);
    }
}
