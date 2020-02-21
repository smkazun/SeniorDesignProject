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

namespace OpenSourceBlog.Test
{
    /// <summary>
    /// Summary description for HomeControllerTest
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {

        public HomeControllerTest()
        {  

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
                BlogId = Guid.Parse("81acc52b-040c-4456-8820-dd21f6122fbc"),
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
                BlogId = Guid.Parse("11acc52b-040c-4456-8820-dd21f6122fbc"),
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
                BlogId = Guid.Parse("21acc52b-040c-4456-8820-dd21f6122fbc"),
                PostId = Guid.NewGuid(),
                Title = "No sort",
                Description = "Description",
                PostContent = "<p>Sample blog post</p>",
                DateCreated = new DateTime(2019, 3, 27),
                DateModified = DateTime.Now,
                Author = "SortingTest",
                IsPublished = false,
                IsCommentEnabled = false,
                Rating = 1
            });

            return postList;
        }

        [TestMethod]
        public void TestIndexMostRecentViewData()
        {
            // Arrange
            var mockRepo = new Mock<PostRepository>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(GetPosts());
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = controller.mostRecentSort() as ViewResult;

            // Assert
            var post = (List<Post>)result.ViewData.Model;
            Assert.AreEqual("Most Recent", post[0].Title);
            Assert.AreEqual(new DateTime(2019, 3, 27), post[0].DateCreated);
          
        }

        [TestMethod]
        public void TestIndexLeastRecentViewData()
        {
            // Arrange
            var mockRepo = new Mock<PostRepository>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(GetPosts());
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = controller.leastRecentSort() as ViewResult;

            // Assert
            var post = (List<Post>)result.ViewData.Model;
            Assert.AreEqual("Least Recent", post[0].Title);
            Assert.AreEqual(new DateTime(2015, 5, 10), post[0].DateCreated);
            
        }

        [TestMethod]
        public void TestIndexHighestRatedViewData()
        {
            // Arrange
            var mockRepo = new Mock<PostRepository>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(GetPosts());
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = controller.highestRatedSort() as ViewResult;

            // Assert
            var post = (List<Post>)result.ViewData.Model;
            Assert.AreEqual("Highest Rated", post[0].Title);
            Assert.AreEqual(10, post[0].Rating);
        }
    }
}

