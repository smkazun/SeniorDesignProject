using OpenSourceBlog.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenSourceBlog.Database.Interfaces;
using System.Data.Entity;

namespace OpenSourceBlog.Database.Repositories
{
    public class PostRepository : GenericRepository<Post, int>, IPostRepository
    {
        public PostRepository(ApplicationContext context) : base(context)
        {
        }

        public void DeletePost(int id)
        {
            Post existing = Get(id);
            existing.IsDeleted = true;
            existing.IsPublished = false;
            _ctx.Entry(existing).State = EntityState.Modified;

        }
    }
}
