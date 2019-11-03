﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using OpenSourceBlog.Core.Models;

namespace OpenSourceBlog.Infrastructure.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("name=DefaultConnection")
        {

        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        public DbSet<Blog> Blogs { get; set; }
    }
}
