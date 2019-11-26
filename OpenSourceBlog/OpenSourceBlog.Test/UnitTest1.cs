using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;

namespace OpenSourceBlog.Test
{
    [TestClass]
    public class UnitTest1 : IRepositoryTest
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
            throw new NotImplementedException();
        }
        [TestMethod]
        public void Create()
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public void Update()
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
