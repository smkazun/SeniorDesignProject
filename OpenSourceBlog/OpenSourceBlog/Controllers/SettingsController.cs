using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;

namespace OpenSourceBlog.Controllers
{
    [Authorize(Roles = "Administrators,Editors")]
    public class SettingsController : Controller
    {
        private ISettingRepository db;

        public SettingsController(ISettingRepository db)
        {
            this.db = db;
        }

        //Initial Page
        // GET: Settings
        public ActionResult Index()
        {
            return View("Index", db.GetSettings());
        }

        
        // GET: Settings/ManageSettings
        public ActionResult ManageSettings()
        {
            return View("ManageSettings", db.GetSettings());
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

            return View("ManageSettings");
        }
       

    }
}