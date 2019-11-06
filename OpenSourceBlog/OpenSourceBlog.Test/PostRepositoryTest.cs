using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSourceBlog.Core.Models;
using OpenSourceBlog.Infrastructure.Repositories;

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
            Post result = repo.Get(1);
            if (result != null)
            {
                return;
            }
            Post p = new Post();
            p.PostRowId = 1;
            p.BlogId = Guid.Parse("71acc52b-040c-4456-8820-dd21f6122fbc");
            Guid PostId = new Guid();
            p.PostId = PostId;
            p.Title = "Welcome to the Open Source .NET Blog using MS SQL";
            p.Description = "Description";
            p.PostContent = "<p>Sample blog post</p>";
            p.DateCreated = DateTime.Now;
            p.DateModified = DateTime.Now;
            p.Author = "PostRepositoryTest";
            p.IsPublished = false;
            p.IsCommentEnabled = false;
            repo.Create(p);
            result = repo.Get(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(PostId, result.PostId);
        }
        [TestMethod]
        public void Update()
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public void Delete()
        {
            repo.Delete(1);
            Post result = repo.Get(1);
            Assert.IsNull(result);
        }
    }
}
