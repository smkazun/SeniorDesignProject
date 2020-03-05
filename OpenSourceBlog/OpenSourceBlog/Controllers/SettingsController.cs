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
        private ModelStateDictionary _modelState;
        private static readonly HashSet<string> AllTimeZoneIds = new HashSet<string>(TimeZoneInfo.GetSystemTimeZones()
                                                                                                 .Select(tz => tz.Id));

        public SettingsController(ISettingRepository db)
        {
            this.db = db;
        }

        //Initial Page
        // GET: Settings
        public ActionResult Index()
        {
            return View("Index", db.GetSettings()); //need getBasicSettings. possible?
        }


        // GET: Settings/ManageSettings
        public ActionResult ManageSettings()
        {
            return View("ManageSettings", db.GetSettings());
        }

        // POST: Settings/ManageSettings
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageSettings([Bind(Include = "SettingName, SettingValue")] List<Setting> settings)
        {
            if (ModelState.IsValid)
            {
                foreach(Setting setting in settings)
                {
                    if(setting.SettingName.Equals("# posts per page") && int.TryParse(setting.SettingValue, out int j))
                    {
                        db.Update(setting);
                    }
                    else
                    {
                        _modelState.AddModelError("Number of posts", "Must be an integer");
                        //could not be parsed
                    }

                    if (setting.SettingName.Equals("Timezone") && AllTimeZoneIds.Contains(setting.SettingValue))
                    {
                        db.Update(setting);
                    }
                    else
                    {
                        _modelState.AddModelError("Timezone", "Must be a valid timezone format");
                        //not a timezone
                    }


                    db.Update(setting);
                }

                return View("Index", settings); //redirect
                
            }

            return View("ManageSettings");
        }
       

    }
}