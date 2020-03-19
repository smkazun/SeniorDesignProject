using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSourceBlog.Controllers;
using OpenSourceBlog.Database.Repositories;
using System.Web.Mvc;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Interfaces;
using Moq;
using System.Linq;
using OpenSourceBlog.DAL;
using PagedList;
using System.Net;
using OpenSourceBlog.Models;

namespace OpenSourceBlog.Test
{
    /// <summary>
    /// Summary description for HomeControllerTest
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IPostRepository> mockRepo;
        private Mock<ISettingsRepository> mockSettingRepo;
        private Mock<IUnitOfWork> mockuow;
        private List<Setting> settingsList;

        [TestInitialize]
        public void TestSetup()
        {
            settingsList = new List<Setting>() {

                new Setting()
                {
                    BlogId = Guid.Parse("71acc52b-040c-4456-8820-dd21f6122fbc"),
                    SettingRowId = 1,
                    SettingName = "Blog Title",
                    SettingValue = "OpenSourceBlog",

                },
                new Setting()
                {
                    BlogId = Guid.Parse("71acc52b-040c-4456-8820-dd21f6122fbc"),
                    SettingRowId = 2,
                    SettingName = "Blog Description",
                    SettingValue = "This is our OpenSourceBlog",

                },
                new Setting()
                {
                    BlogId = Guid.Parse("71acc52b-040c-4456-8820-dd21f6122fbc"),
                    SettingRowId = 3,
                    SettingName = "# posts per page",
                    SettingValue = "2",

                },
                new Setting()
                {
                    BlogId = Guid.Parse("71acc52b-040c-4456-8820-dd21f6122fbc"),
                    SettingRowId = 4,
                    SettingName = "Language",
                    SettingValue = "English",

                },
                new Setting()
                {
                    BlogId = Guid.Parse("71acc52b-040c-4456-8820-dd21f6122fbc"),
                    SettingRowId = 4,
                    SettingName = "Timezone",
                    SettingValue = "some time",

                },
            };

            // Arrange
            mockRepo = new Mock<IPostRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(GetPosts());

            mockSettingRepo = new Mock<ISettingsRepository>();
            mockSettingRepo.Setup(repo => repo.GetSettings()).Returns(this.settingsList);

            mockuow = new Mock<IUnitOfWork>();
            mockuow.Setup(u => u._postRepository).Returns(mockRepo.Object);
            mockuow.Setup(u => u._settingsRepository).Returns(mockSettingRepo.Object);
        }

        private List<Post> GetPosts()
        {
            var postList = new List<Post>();
            postList.Add(new Post()
            {
                BlogId = Guid.Parse("71acc52b-040c-4456-8820-dd21f6122fbc"),
                PostId = Guid.NewGuid(),
                Title = "Most Recent",
                Description = "Description",
                PostContent = "<p>Sample blog post</p>",
                DateCreated = new DateTime(2019, 3, 27),
                DateModified = DateTime.Now,
                Author = "SortingTest",
                IsPublished = true,
                IsCommentEnabled = false,
                Rating = 5
        });
            postList.Add(new Post()
            {
                BlogId = Guid.Parse("71acc52b-040c-4456-8820-dd21f6122fbc"),
                PostId = Guid.NewGuid(),
                Title = "Least Recent",
                Description = "Description",
                PostContent = "<p>Sample blog post</p>",
                DateCreated = new DateTime(2015, 5, 10),
                DateModified = DateTime.Now,
                Author = "SortingTest",
                IsPublished = true,
                IsCommentEnabled = false,
                Rating = 2
            });
            postList.Add(new Post()
            {
                BlogId = Guid.Parse("71acc52b-040c-4456-8820-dd21f6122fbc"),
                PostId = Guid.NewGuid(),
                Title = "Highest Rated",
                Description = "Description",
                PostContent = "<p>Sample blog post</p>",
                DateCreated = new DateTime(2018, 6, 13),
                DateModified = DateTime.Now,
                Author = "SortingTest",
                IsPublished = true,
                IsCommentEnabled = false,
                Rating = 10
            });
            //not published, shouldnt sort
            postList.Add(new Post()
            {
                BlogId = Guid.Parse("71acc52b-040c-4456-8820-dd21f6122fbc"),
                PostId = Guid.NewGuid(),
                Title = "No sort",
                Description = "Description",
                PostContent = "<p>Sample blog post</p>",
                DateCreated = new DateTime(2019, 3, 27),
                DateModified = DateTime.Now,
                Author = "SortingTest",
                IsPublished = false,
                IsDeleted = true,
                IsCommentEnabled = false,
                Rating = 1
            });

            return postList;
        }

        [TestMethod]
        public void TestPostSortMostRecentViewData()
        {
            var controller = new HomeController(mockuow.Object);

            // Act
            var result = controller.postSort(1) as ViewResult;

            // Assert
            var post = (PagedList<Post>)result.ViewData.Model;
            Assert.AreEqual("Most Recent", post[0].Title);
            Assert.AreEqual(new DateTime(2019, 3, 27), post[0].DateCreated);
          
        }

        [TestMethod]
        public void TestPostSortLeastRecentViewData()
        {
            var controller = new HomeController(mockuow.Object);

            var result = controller.postSort(2) as ViewResult;

            var post = (PagedList<Post>)result.ViewData.Model;
            Assert.AreEqual("Least Recent", post[0].Title);
            Assert.AreEqual(new DateTime(2015, 5, 10), post[0].DateCreated);
            
        }

        [TestMethod]
        public void TestPostSortHighestRatedViewData()
        {
            var controller = new HomeController(mockuow.Object);

            var result = controller.postSort(3) as ViewResult;
            var post = (PagedList<Post>)result.ViewData.Model;

            Assert.AreEqual("Highest Rated", post[0].Title);
            Assert.AreEqual(10, post[0].Rating);
        }

        [TestMethod]
        public void TestPostSortNullId()
        {
            var controller = new HomeController(mockuow.Object);

            var result = controller.postSort(null) as HttpStatusCodeResult;

            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void TestPostSortPaging()
        {
            var controller = new HomeController(mockuow.Object);

            var result = controller.postSort(3) as ViewResult;
            var post = (PagedList<Post>)result.ViewData.Model;

            Assert.AreEqual(1, post.PageNumber);
            Assert.AreEqual(2, post.PageCount);
        }

        [TestMethod]
        public void TestIndexView()
        {
            var controller = new HomeController(mockuow.Object);

            var result = controller.Index(null, null, 1) as ViewResult;

            Assert.AreEqual("This is our OpenSourceBlog", result.ViewData["BlogDesc"]);
            Assert.AreEqual("OpenSourceBlog", result.ViewData["BlogTitle"]);
        }

        [TestMethod]
        public void TestIndexViewData()
        {
            var controller = new HomeController(mockuow.Object);

            var result = controller.Index(null, null, null) as ViewResult;

            var homeViewModel = (HomeViewModel)result.ViewData.Model;
            var postList = (PagedList<Post>)homeViewModel.Post;

            Assert.AreEqual("Highest Rated", postList[0].Title);
            Assert.AreEqual(new DateTime(2018, 6, 13), postList[0].DateCreated);
        }

        [TestMethod]
        public void TestIndexSearchStringView()
        {
            var controller = new HomeController(mockuow.Object);

            var result = controller.Index("Most", null, null) as ViewResult;

            //Assert.AreEqual("Most", result.ViewBag.CurrentFilter); //TODO
        }

        [TestMethod]
        public void TestIndexSearchStringViewData_SinglePost()
        {
            var controller = new HomeController(mockuow.Object);

            var result = controller.Index("high", null, null) as ViewResult;
            var homeViewModel = (HomeViewModel)result.ViewData.Model;
            var post = (PagedList<Post>)homeViewModel.Post;

            Assert.AreEqual("Highest Rated", post[0].Title);
            Assert.AreEqual(new DateTime(2018, 6, 13), post[0].DateCreated);
            Assert.AreEqual(1, post.PageNumber);
            Assert.AreEqual(1, post.PageCount);

        }

        [TestMethod]
        public void TestIndexSearchStringViewData_MultiplePosts()
        {
            var controller = new HomeController(mockuow.Object);

            var result = controller.Index("e", null, null) as ViewResult;
            var homeViewModel = (HomeViewModel)result.ViewData.Model;
            var post = (PagedList<Post>)homeViewModel.Post;

            Assert.AreEqual("Highest Rated", post[0].Title); //TODO ??? Most Recent
            Assert.AreEqual("Least Recent", post[1].Title);
            //Assert.AreEqual(new DateTime(2019, 3, 27), post[0].DateCreated);
            Assert.AreEqual(1, post.PageNumber);
            Assert.AreEqual(2, post.PageCount);

        }


        [TestMethod]
        public void TestArchiveViewData()
        {
            var controller = new HomeController(mockuow.Object);

            var result = controller.Archive() as ViewResult;
            var postList = (List<Post>)result.ViewData.Model;

            Assert.AreEqual("No sort", postList[0].Title);
            Assert.AreEqual("Description", postList[0].Description);

        }

        [TestMethod]
        public void TestArchiveView()
        {
            var controller = new HomeController(mockuow.Object);

            var result = controller.Archive() as ViewResult;

            Assert.AreEqual("Archive", result.ViewName);
        }

    }
}

