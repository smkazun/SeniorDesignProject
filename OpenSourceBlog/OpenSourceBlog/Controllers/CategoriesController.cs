using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Models;

namespace OpenSourceBlog.Controllers
{
    public class CategoriesController : Controller
    {
//        private ApplicationDbContext db = new ApplicationDbContext();
        private ICategoryRepository db;

        public CategoriesController(ICategoryRepository db)
        {
            this.db = db;
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View("~/Views/Admin/Categories/CategoriesIndex.cshtml",db.GetAll());
        }

        // GET: Categories
        public ActionResult PartialIndex()
        {
            return PartialView("~/Views/Admin/Categories/Index.cshtml",db.GetAll());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Get(Convert.ToInt32(id));
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/Admin/Categories/Details.cshtml", category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View("~/Views/Admin/Categories/Create.cshtml");
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryRowId,BlogId,CategoryId,CategoryName,Description,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Create(category);
                return RedirectToAction("Index");
            }

            return PartialView("~/Views/Admin/Categories/Create.cshtml", category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Get(Convert.ToInt32(id));
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/Admin/Categories/Edit.cshtml", category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryRowId,BlogId,CategoryId,CategoryName,Description,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Update(category);
                return RedirectToAction("Index");
            }
            return PartialView("~/Views/Admin/Categories/Edit.cshtml", category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Get(Convert.ToInt32(id));
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/Admin/Categories/Delete.cshtml", category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
