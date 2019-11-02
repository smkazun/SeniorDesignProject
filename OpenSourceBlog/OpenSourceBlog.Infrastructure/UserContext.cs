using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Infrastructure
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=DefaultConnection")
        {

        }
        public DbSet Users { get; set; }
    }
}
