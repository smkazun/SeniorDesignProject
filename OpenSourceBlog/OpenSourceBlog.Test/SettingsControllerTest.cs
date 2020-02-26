using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSourceBlog.Database.Repositories;
using System.Web.Mvc;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Controllers;
using Moq;
using OpenSourceBlog.Database.Interfaces;
using System.Data.Entity;

namespace OpenSourceBlog.Test
{
    /// <summary>
    /// Summary description for SettingsControllerTest
    /// </summary>
    [TestClass]
    public class SettingsControllerTest
    {
        private SettingRepository repo;
        private TestContext testContextInstance;

        private List<Setting> settingsList;

        [TestInitialize]
        public void TestSetup()
        {
            repo = new SettingRepository();



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
                    SettingValue = "20",

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

                }
            };
        }
         

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

        //GET
        [TestMethod]
        public void TestIndexView()
        {
            
            var mockRepo = new Mock<ISettingRepository>();
            mockRepo.Setup(repo => repo.GetSettings()).Returns(this.settingsList);
            var controller = new SettingsController(mockRepo.Object);

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        //GET
        [TestMethod]
        public void TestManageSettingsView()
        {
            var mockRepo = new Mock<ISettingRepository>();
            mockRepo.Setup(repo => repo.GetSettings()).Returns(this.settingsList);
            var controller = new SettingsController(mockRepo.Object);

            var result = controller.ManageSettings() as ViewResult;

            Assert.AreEqual("ManageSettings", result.ViewName);
        }

        //GET
        [TestMethod]
        public void TestIndexViewData()
        {
            
            var mockRepo = new Mock<ISettingRepository>();
            mockRepo.Setup(repo => repo.GetSettings()).Returns(this.settingsList);
            var controller = new SettingsController(mockRepo.Object);

            var result = controller.Index() as ViewResult;
            var setting = (List<Setting>)result.ViewData.Model;

            Assert.AreEqual("Blog Title", setting[0].SettingName);
            Assert.AreEqual("Blog Description", setting[1].SettingName);
            Assert.AreEqual("# posts per page", setting[2].SettingName);
            Assert.AreEqual("Language", setting[3].SettingName);
            Assert.AreEqual("Timezone", setting[4].SettingName);
            Assert.AreEqual(GlobalVars.BlogId, setting[0].BlogId);  

        }

        //GET
        [TestMethod]
        public void TestManageSettingsViewData()
        {

            var mockRepo = new Mock<ISettingRepository>();
            mockRepo.Setup(repo => repo.GetSettings()).Returns(this.settingsList); //TODO need to mock update

            //TODO finish
           


            var controller = new SettingsController(mockRepo.Object);

            var result = controller.ManageSettings(this.settingsList) as ViewResult;
            var setting = (List<Setting>)result.ViewData.Model;




            Assert.AreEqual("Blog Title", setting[0].SettingName);
            Assert.AreEqual("Blog Description", setting[1].SettingName);
            Assert.AreEqual("# posts per page", setting[2].SettingName);
            Assert.AreEqual("Language", setting[3].SettingName);
            Assert.AreEqual("Timezone", setting[4].SettingName);

            Assert.AreEqual("OpenSourceBlog", setting[0].SettingValue);
            Assert.AreEqual("This is our Open Source Blog", setting[1].SettingValue);
            Assert.AreEqual("20", setting[2].SettingValue);
            Assert.AreEqual("English", setting[3].SettingValue);
            Assert.AreEqual("some time", setting[4].SettingValue);
        }

        //POST
        [TestMethod]
        public void TestManageSettingsRedirect()
        {

            var mockRepo = new Mock<ISettingRepository>();
            mockRepo.Setup(repo => repo.GetSettings()).Returns(this.settingsList);
            
            var controller = new SettingsController(mockRepo.Object);

            var result = (RedirectToRouteResult)controller.ManageSettings(this.settingsList);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        

        //POST
        [TestMethod]
        public void TestManageSettingsInvalidModelState()
        {
            //if invalid model state, then use the default settings
            var mockRepo = new Mock<ISettingRepository>();
            mockRepo.Setup(repo => repo.GetSettings()).Returns(this.settingsList); //TODO mock update
            var controller = new SettingsController(mockRepo.Object);

            controller.ModelState.AddModelError(String.Empty, "Error in modelstate");
            var result = controller.ManageSettings(new List<Setting>()) as ViewResult;
            //controller.ViewData.ModelState.Clear();

            
            Assert.AreEqual("ManageSettings", result.ViewName);
        }

    }
}
