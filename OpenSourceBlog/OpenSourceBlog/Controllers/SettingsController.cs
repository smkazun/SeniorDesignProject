using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;

namespace OpenSourceBlog.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private SettingRepository db = new SettingRepository();

        //temp
        List<Setting> settingList = new List<Setting>(){
                            new Setting() { BlogId = System.Guid.NewGuid(), SettingName = "Blog Title", SettingValue = "Test Blog 001" } ,
                            new Setting() { BlogId = System.Guid.NewGuid(), SettingName = "Blog Description",  SettingValue = "This is a description of the blog" } ,
                            new Setting() { BlogId = System.Guid.NewGuid(), SettingName = "# posts per page",  SettingValue = "10" },
                            new Setting() { BlogId = System.Guid.NewGuid(), SettingName = "Blog Language",  SettingValue = "English" }


                        };
        

        //Initial Page
        // GET: Settings
        public ActionResult Index(string returnUrl)
        {
            
            ViewBag.ReturnUrl = returnUrl;
            return View(db.GetAll());
            //return View(settingList);
        }

        
        // GET: Settings/ManageSettings
        public ActionResult ManageSettings()
        {
            return View(db.GetAll());
        }

        // POST: Settings/ManageSettings
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageSettings([Bind(Include = "SettingRowId, BlogId, SettingName, SettingValue")] List<Setting> settings)
        {
            if (ModelState.IsValid)
            {
                foreach(Setting setting in settings)
                {
                    db.Update(setting);
                }

                //db.Update(setting);
                return RedirectToAction("Index");
            }
            Setting emptySetting = new Setting()
            {
                BlogId = GlobalVariables.BlogId,

            };
            ViewData["sitesetting"] = emptySetting;

            return View(settings);
        }
        

        // POST: Settings/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update( Setting setting, string returnUrl)
        {     

            if (ModelState.IsValid)
            {
                db.Update(setting);
                return RedirectToAction("ManageSettings");
            }
            //return View(setting);
            return RedirectToLocal(returnUrl);
        }



        //helper method
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Settings");
        }

    }
}