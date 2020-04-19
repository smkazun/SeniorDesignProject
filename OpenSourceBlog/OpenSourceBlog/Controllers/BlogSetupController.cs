using OpenSourceBlog.DAL;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenSourceBlog.Controllers
{
    public class BlogSetupController : Controller
    {
        private IUnitOfWork uow;

        public BlogSetupController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        // GET: BlogSetup
        [HttpGet]
        public ActionResult BlogSetup()
        {
            BlogSetupViewModel test = new BlogSetupViewModel();
            test.settings = new List<Setting>();//empty settings list

            return View("BlogSetup", test);
        }

        //POST: /BlogSetup/BlogSetup
        [HttpPost]
        public ActionResult BlogSetup(BlogSetupViewModel model)
        {
            //create new blogid, new settings, etc.
            var NewBlogId = GlobalVars.CreateBlogId;

            var newBlog = new Blog()
            {
                BlogId = NewBlogId,
                BlogName = model.BlogTitle,
                Hostname = "",
                IsActive = true,
                IsPrimary = false,
                StorageContainerName = "",
                VirtualPath = "~/",
                IsAnyTextBeforeHostnameAccepted = false,
                IsSiteAggregation = false,

            };

            var newSettings = new List<Setting>() {

                new Setting(){
                    BlogId = NewBlogId,
                    SettingRowId = 6, //TODO: fix
                    SettingName = "Blog Title",
                    SettingValue = model.BlogTitle,
                },
               new Setting(){
                    BlogId = NewBlogId,
                    SettingRowId = 7, //TODO: fix
                    SettingName = "Blog Description",
                    SettingValue = model.BlogDescription,
                },
               new Setting(){
                    BlogId = NewBlogId,
                    SettingRowId = 8, //TODO: fix
                    SettingName = "# posts per page",
                    SettingValue = "5", //default
                },
               new Setting(){
                    BlogId = NewBlogId,
                    SettingRowId = 9, //TODO: fix
                    SettingName = "Blog Language",
                    SettingValue = "English", //default
                },
               new Setting(){
                    BlogId = NewBlogId,
                    SettingRowId = 10, //TODO: fix
                    SettingName = "Timezone",
                    SettingValue = TimeZone.CurrentTimeZone.ToString(), //TODO: 
                },
               new Setting(){
                    BlogId = NewBlogId,
                    SettingRowId = 11, //TODO: fix
                    SettingName = "Theme",
                    SettingValue = "defualt", //TODO:
                },

            };

            model.blog = newBlog;
            model.settings = newSettings;

            //if (ModelState.IsValid)
            //{
                /*
                foreach(var setting in settings)
                {
                    uow._settingsRepository.Create(setting);
                }*/

                uow._blogRepository.Create(newBlog);

                
                //uow.Save();

                return RedirectToAction("Index", "Home");
            //}

            //return View();
        }

       
    }
    
}