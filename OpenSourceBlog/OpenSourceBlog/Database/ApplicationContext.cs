using System.Data.Entity;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database
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
        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Right> Rights { get; set; }
        public DbSet<RightRole> RightRoles { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<StopWord> StopWords { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
    }
}
