using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using OpenSourceBlog.Core.Models;

namespace OpenSourceBlog.Infrastructure.Context
{
    public partial class UserContext : DbContext
    {
        public UserContext() : base("name=DefaultConnection")
        {

        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}
        public DbSet<User> AspNetUsers { get; set; }
    }
}
