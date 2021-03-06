﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;

namespace OpenSourceBlog.Test
{
    [TestClass]
    public class BlogRepositoryTest : IRepositoryTest
    {
        private GenericRepository<Blog, int> repo;
        [TestInitialize]
        public void TestSetup()
        {
            repo = new GenericRepository<Blog, int>();
        }
        [TestMethod]
        public void GetAll()
        {
            IEnumerable<Blog> result = repo.GetAll();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Get()
        {
            Blog result = repo.Get(1);
            Assert.IsNotNull(result);
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
