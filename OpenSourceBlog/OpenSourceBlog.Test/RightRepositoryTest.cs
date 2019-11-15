using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSourceBlog.Core.Models;
using OpenSourceBlog.Infrastructure.Repositories;

namespace OpenSourceBlog.Test
{
    [TestClass]
    public class RightRepositoryTest : IRepositoryTest
    {
        private RightRepository repo;

        [TestInitialize]
        public void TestSetup()
        {
            repo = new RightRepository();
        }
        [TestMethod]
        public void GetAll()
        {
            IEnumerable<Right> result = repo.GetAll();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Get()
        {
            Right result = repo.Get(1202);
            Assert.IsNotNull(result);
            Assert.AreEqual("AccessAdminPages", result.RightName);
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
