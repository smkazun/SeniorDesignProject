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
    [Authorize(Roles = "Admin")]
    public class SiteSettingsController : Controller
    {
        private SettingRepository db = new SettingRepository();

        // GET: SiteSettings
        public ActionResult Index()
        {
            return View(db.GetAll());
        }


        // POST: Settings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostRowId,BlogId,PostId,Title,Description,PostContent,DateCreated,DateModified,Author,IsPublished,IsCommentEnabled,Raters,Rating,Slug,IsDeleted")] Setting setting)
        {
            if (ModelState.IsValid)
            {
                db.Create(setting);
                return RedirectToAction("Index");
            }
            Setting emptySetting = new Setting()
            {
                BlogId = GlobalVariables.BlogId,
                
            };
            //ViewData["sitesetting"] = emptySetting;

            return View(setting);
        }

        // GET: Settings/Update/5
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Setting setting = db.Get(Convert.ToInt32(id));
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Settings/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Setting setting)
        {
            
            if (ModelState.IsValid)
            {
                db.Update(setting);
                return RedirectToAction("Index");
            }
            return View(setting);
        }



        //blog title
        //description
        //posts per page
        //blog language
        //timezone


    }
}