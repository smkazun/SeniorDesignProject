﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        [TestMethod]
        public void Get()
        {
            AspNetUser result = repo.Get("916fadc0-45c8-479e-a2dc-0301c82db7ee");
            Assert.IsNotNull(result);
            Console.WriteLine(result.Email);
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
        [TestMethod]
        public void FindByUserName()
        {
            AspNetUser result = repo.FindByUserName("pjd@iastate.edu");
            Assert.IsNotNull(result);
            Console.WriteLine(result.UserName);
        }
        [TestMethod]
        public void GetRole()
        {
            AspNetRole role = repo.GetRoleByUserName("pjd@iastate.edu");
            Assert.IsNotNull(role);
            Console.WriteLine(role.Name);
        }
    }
}
