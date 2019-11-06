using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSourceBlog.Core.Models;
using OpenSourceBlog.Infrastructure.Repositories;

namespace OpenSourceBlog.Test
{
    [TestClass]
    public class UserRepositoryTest : IRepositoryTest
    {
        private UserRepository repo;
        [TestInitialize]
        public void TestSetup()
        {
            repo = new UserRepository();
        }
        [TestMethod]
        public void GetAll()
        {
            IEnumerable<AspNetUser> result = repo.GetAll();
            Assert.IsNotNull(result);
        }
        
        public void Get()
        {
            
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
