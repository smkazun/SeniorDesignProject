using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Core;
using System.Data.Entity;
using OpenSourceBlog.Core.Models;
using OpenSourceBlog.Infrastructure.Context;

namespace OpenSourceBlog.Infrastructure.Initialize
{
    public class BlogInitializeDB : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            context.Blogs.Add(new Blog
            {
                BlogRowId = 1, BlogId = Guid.NewGuid(), BlogName = "Primary", Hostname = "",
                IsAnyTextBeforeHostnameAccepted = false, StorageContainerName = "", VirtualPath = "~/",
                IsPrimary = true, IsActive = true, IsSiteAggregation = false
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}