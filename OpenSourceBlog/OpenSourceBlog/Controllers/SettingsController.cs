﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenSourceBlog.DAL;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;

namespace OpenSourceBlog.Controllers
{
    [Authorize(Roles = "Administrators,Editors")]
    public class SettingsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private static readonly HashSet<string> AllTimeZoneIds = new HashSet<string>(TimeZoneInfo.GetSystemTimeZones()
                                                                                                 .Select(tz => tz.DisplayName));

        public SettingsController(IUnitOfWork uow)
        {
            this._unitOfWork = uow;
        }

        //Initial Page
        // GET: Settings
        public ActionResult Index()
        {
           return View("Index", _unitOfWork._settingsRepository.GetSettings()); 
        }


        // GET: Settings/ManageSettings
        public ActionResult ManageSettings()
        {
            return View("ManageSettings", _unitOfWork._settingsRepository.GetSettings());
        }
        // GET: Settings/ManageSettings
        public IEnumerable<string> GetThemes()
        {
            return Directory.EnumerateFiles(Server.MapPath(Server.MapPath("~/Content/themes")));

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

                    if (setting.SettingName.Equals("# posts per page"))
                    {
                        if(int.TryParse(setting.SettingValue, out int j))
                        {
                            _unitOfWork._settingsRepository.Update(setting);

                        }
                        else
                        {
                            ModelState.AddModelError(String.Empty, "Must be an integer");
                        }
                    }
                    else if (setting.SettingName.Equals("Timezone"))
                    {
                        if(AllTimeZoneIds.Contains(setting.SettingValue))
                        {
                            _unitOfWork._settingsRepository.Update(setting);
                        }
                        else
                        {
                            ModelState.AddModelError("test","Must be a valid timezone format");
                        }
                        
                    }
                    else
                    {
                        _unitOfWork._settingsRepository.Update(setting);
                    }
                  

                }
                _unitOfWork.Save();
                return View("ManageSettings", settings); //redirect
                
            }

            return View("ManageSettings");
        }
       

    }
}