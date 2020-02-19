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

        //Initial Page
        // GET: Settings
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(db.GetAll());
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

                return RedirectToAction("Index");
            }

            
            Setting emptySetting = new Setting()
            {
                BlogId = GlobalVariables.BlogId,

            };
            ViewData["sitesetting"] = emptySetting;

            return View(settings);
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