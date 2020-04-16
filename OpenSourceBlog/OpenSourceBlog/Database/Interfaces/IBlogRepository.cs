using OpenSourceBlog.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IBlogRepository : IGenericRepository<Blog, int>
    {
    }
}