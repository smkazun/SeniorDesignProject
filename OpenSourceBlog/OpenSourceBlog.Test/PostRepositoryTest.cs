using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;

namespace OpenSourceBlog.Test
{
    [TestClass]
    public class PostRepositoryTest : IRepositoryTest
    {
        private PostRepository repo;

        [TestInitialize]
        public void TestSetup()
        {
            repo = new PostRepository();
        }
        [TestMethod]
        public void GetAll()
        {
            IEnumerable<Post> result = repo.GetAll();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Get()
        {
            Post result = repo.Get(1);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Create()
        {
            Post p = new Post();
            //p.PostRowId = 1; this is not needed as the
            //database will auto increment accordingly
            p.BlogId = Guid.Parse("71acc52b-040c-4456-8820-dd21f6122fbc");
            p.PostId = Guid.NewGuid();
            p.Title = "Welcome to the Open Source .NET Blog using MS SQL";
            p.Description = "Description";
            p.PostContent = "<p>Sample blog post</p>";
            p.DateCreated = DateTime.Now;
            p.DateModified = DateTime.Now;
            p.Author = "PostRepositoryTest";
            p.IsPublished = false;
            p.IsCommentEnabled = false;
            repo.Create(p);
            Post result = repo.Get(repo.GetAll().Count());
            Assert.IsNotNull(result);
            Assert.AreEqual(p.PostId, result.PostId);
        }
        
        public void Update()
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public void Delete()
        {
            repo.Delete(2);
            Post result = repo.Get(2);
            Assert.IsNull(result);
        }
    }
}
