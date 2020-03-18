using OpenSourceBlog.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IPostRepository : IGenericRepository<Post, int>
    {
        void DeletePost(int id);
    }
}

