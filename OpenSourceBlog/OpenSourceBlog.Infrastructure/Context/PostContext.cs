using System.Data.Entity;
using OpenSourceBlog.Core.Models;

namespace OpenSourceBlog.Infrastructure.Context
{
    public class PostContext : DbContext
    {
        public PostContext() : base("name=DefaultConnection")
        {

        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        public DbSet<Post> Posts { get; set; }
    }
}