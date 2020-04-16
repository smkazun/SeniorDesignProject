using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSourceBlog.Database.Repositories
{
    public class BlogRepository : GenericRepository<Blog, int>, IBlogRepository
    {
        public BlogRepository(ApplicationContext context) : base(context)
        {
        }
    }
}