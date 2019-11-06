using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Core.Models;

namespace OpenSourceBlog.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostNotify> PostNotifies { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Right> Rights { get; set; }
        public DbSet<RightRole> RightRoles { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<StopWord> StopWords { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<Role> Roles { get; set; }
    }
}
