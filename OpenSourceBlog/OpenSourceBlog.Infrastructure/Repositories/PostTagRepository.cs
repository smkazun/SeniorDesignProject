using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Core.Interfaces;
using OpenSourceBlog.Core.Models;

namespace OpenSourceBlog.Infrastructure.Repositories
{
    public class PostTagRepository : IRepository<PostTag, int>
    {
        private readonly ApplicationContext ctx = new ApplicationContext();
        public IEnumerable<PostTag> GetAll()
        {
            return ctx.PostTags.ToList();
        }

        public PostTag Get(int id)
        {
            return ctx.PostTags.Find(id);
        }

        public void Create(PostTag entity)
        {
            ctx.PostTags.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(int id, PostTag entityNew)
        {
            //ToDo Update and change the old data to new data
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            PostTag pt = Get(id);
            ctx.PostTags.Remove(pt);
            ctx.SaveChanges();
        }
    }
}
