using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSourceBlog.Controllers;
using Moq;
using OpenSourceBlog.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using Microsoft.Owin.Security;
using System.Web.Mvc;

namespace OpenSourceBlog.Test
{

    [TestClass]
    public class AccountControllerTest
    {
        private Mock<ApplicationUserManager> mockUserManager;
        private Mock<ApplicationSignInManager> mockSignInManager;
        private Mock<ApplicationRoleManager> mockAppRoleManager;
        private AccountController testController;

        private readonly string _email;
        private readonly string _subject;
        private readonly string _message;
        private readonly ApplicationUser _applicationUser;
 

        public AccountControllerTest()
        {
            
            testController = new AccountController();

            _email = "test@gmail.com";
            _subject = "This is a test";
            _message = "hello tester";
            _applicationUser = new ApplicationUser { UserName = _email, Email = _email };
           

        }

        [TestInitialize]
        public void InitializeTest()
        {
           // HttpContext.Current = CreateHttpContext(userLoggedin: false);
            var mockUserStore = new Mock<IUserStore<ApplicationUser>>();
            var mockUserManager = new Mock<ApplicationUserManager>(mockUserStore.Object);
           // var mockAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockSignInManager = new Mock<ApplicationSignInManager>(mockUserManager.Object);
            var mockRoleManager = new Mock<ApplicationRoleManager>(mockUserStore.Object);

            //testController = new AccountController(mockUserManager.Object, mockSignInManager.Object, mockAppRoleManager.Object);
        }

        public void userLoggedOut_ReturnsView()
        {
            //Arrange - done in initialization
            var accountController = new AccountController(mockUserManager.Object, mockSignInManager.Object, mockAppRoleManager.Object);

            //Act
            var result = accountController.Register();

            //Assert
            //Assert.That(result, Is.TypeOf<ViewResult>()); //TODO fix




        }


        /*
        private Mock<ApplicationUserManager> setupUserManager(ApplicationUser user)
        {
            var manager = new Mock<ApplicationUserManager>();

            manager.Setup(m => m.FindByNameAsync(user.UserName)).ReturnsAsync(user);
            manager.Setup(m => m.FindByIdAsync(user.Id)).ReturnsAsync(user);
            manager.Setup(m => m.FindByEmailAsync(user.Email)).ReturnsAsync(user);
           
            return manager;

        }
        */

       private ApplicationSignInManager setupSignIn(UserManager<ApplicationUser> manager, HttpContext context)
        {

            return null;
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
        public void TestRegisterUser()
        {
            
            //
            // TODO: Add test logic here
            //



        }
    }
}
