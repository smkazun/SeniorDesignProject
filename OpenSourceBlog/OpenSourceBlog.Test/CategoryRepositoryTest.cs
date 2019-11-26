using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;

namespace OpenSourceBlog.Test
{
    [TestClass]
    public class CategoryRepositoryTest : IRepositoryTest
    {
        private CategoryRepository repo;

        [TestInitialize]
        public void TestSetup()
        {
            repo = new CategoryRepository();
        }
        [TestMethod]
        public void GetAll()
        {
            IEnumerable<Category> result = repo.GetAll();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Get()
        {
            Category result = repo.Get(1);
        }
        [TestMethod]
        public void Create()
        {
            Category c = new Category();
            c.BlogId = Guid.Parse("71acc52b-040c-4456-8820-dd21f6122fbc");
            c.CategoryId = Guid.NewGuid();
            c.CategoryName = "All";
            c.Description = "Filters for all possible categories. This is the default option.";
            c.ParentId = null;
            repo.Create(c);
            Category result = repo.Get(repo.GetAll().Count());
            Assert.IsNotNull(result);
            Assert.AreEqual(c.CategoryId, result.CategoryId);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public void Delete()
        {
            int count = repo.GetAll().Count();
            repo.Delete(count);
            Category result = repo.Get(count);
            Assert.IsNull(result);
        }
    }
}
