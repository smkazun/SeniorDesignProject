using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSourceBlog.Core.Models;
using OpenSourceBlog.Infrastructure.Repositories;

namespace OpenSourceBlog.Test
{
    [TestClass]
    public class BlogRepositoryTest
    {
        private BlogRepository repo;
        [TestInitialize]
        public void TestSetup()
        {
            repo = new BlogRepository();
        }

        [TestMethod]
        public void CheckGetByRowId()
        {
            Blog result = repo.Get(1);
            Assert.IsNotNull(result);
        }
    }
}
