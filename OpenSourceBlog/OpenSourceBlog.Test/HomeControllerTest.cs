using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSourceBlog.Controllers;
using OpenSourceBlog.Database.Repositories;
using System.Web.Mvc;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Interfaces;

namespace OpenSourceBlog.Test
{
    /// <summary>
    /// Summary description for HomeControllerTest
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        private IPostRepository repo;

        public HomeControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
            repo = new PostRepository();

            //make an example post
            Post p = new Post();
            
            p.BlogId = Guid.Parse("71acc52b-040c-4456-8820-dd21f6122fbc");
            p.PostId = Guid.NewGuid();
            p.Title = "MostRecent";
            p.Description = "Description";
            p.PostContent = "<p>Sample blog post</p>";
            p.DateCreated = new DateTime(2019, 3, 27);
            p.DateModified = DateTime.Now;
            p.Author = "SortingTest";
            p.IsPublished = false;
            p.IsCommentEnabled = false;
            p.Rating = 5;
            repo.Create(p);

            Post p1 = new Post();

            p1.BlogId = Guid.Parse("87acc52b-040c-4456-8820-dd21f6122fbc");
            p1.PostId = Guid.NewGuid();
            p1.Title = "LeastRecent";
            p1.Description = "Description";
            p1.PostContent = "<p>Sample blog post</p>";
            p1.DateCreated = new DateTime(2015, 5, 10);
            p1.DateModified = DateTime.Now;
            p1.Author = "SortingTest";
            p1.IsPublished = false;
            p1.IsCommentEnabled = false;
            p1.Rating = 2;
            repo.Create(p1);

            Post p2 = new Post();

            p2.BlogId = Guid.Parse("11acc52b-040c-4456-8820-dd21f6122fbc");
            p2.PostId = Guid.NewGuid();
            p2.Title = "Highest Rating";
            p2.Description = "Description";
            p2.PostContent = "<p>Sample blog post</p>";
            p2.DateCreated = new DateTime(2018, 6, 13);
            p2.DateModified = DateTime.Now;
            p2.Author = "SortingTest";
            p2.IsPublished = false;
            p2.IsCommentEnabled = false;
            p2.Rating = 10;
            repo.Create(p2);

        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        
        [TestMethod]
        public void TestIndexView()
        {

            var controller = new HomeController(repo);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        public void TestIndexMostRecentViewData()
        {
            var controller = new HomeController(repo);
            var result = controller.mostRecentSort();
            var resultView = controller.Index() as ViewResult;
            var post = (Post)resultView.ViewData.Model;
            Assert.AreEqual(new DateTime(2019, 3, 27), post.DateCreated);
        }

        [TestMethod]
        public void TestIndexLeastRecentViewData()
        {
            var controller = new HomeController(repo);
            var result = controller.leastRecentSort();
            var resultView = controller.Index() as ViewResult;
            var post = (Post)resultView.ViewData.Model;
            Assert.AreEqual(new DateTime(2015, 5, 10), post.DateCreated);
        }

        [TestMethod]
        public void TestIndexHighestRatedViewData()
        {
            var controller = new HomeController(repo);
            var result = controller.highestRatedSort();
            var resultView = controller.Index() as ViewResult;
            var post = (Post)resultView.ViewData.Model;
            Assert.AreEqual(10, post.Rating);
        }
    }
}
