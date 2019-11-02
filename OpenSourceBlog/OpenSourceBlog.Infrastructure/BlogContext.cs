using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Core;
using System.Data.Entity;

namespace OpenSourceBlog.Infrastructure
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("name=DefaultConnection")
        {

        }
        public DbSet Blogs { get; set; }
    }
}
