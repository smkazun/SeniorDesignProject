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
    public class ManageUsersController : Controller
    {
        private IUserRepository db;

        public ManageUsersController(IUserRepository db)
        {
            this.db = db;
        }

        // GET: ManageUsers
        public ActionResult Index()
        {
            return PartialView("~/Views/Admin/ManageUsers/Index.cshtml",db.GetAll());
        }

        // GET: ManageUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.Get(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/Admin/ManageUsers/Details.cshtml", aspNetUser);
        }

        // GET: ManageUsers/Create
        public ActionResult Create()
        {
            return PartialView("~/Views/Admin/ManageUsers/Create.cshtml");
        }

        // POST: ManageUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db.Create(aspNetUser);
                return RedirectToAction("Index");
            }

            return PartialView("~/Views/Admin/ManageUsers/Create.cshtml", aspNetUser);
        }

        // GET: ManageUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.Get(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/Admin/ManageUsers/Edit.cshtml", aspNetUser);
        }

        // POST: ManageUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db.Update(aspNetUser);
                return RedirectToAction("Index");
            }
            return PartialView("~/Views/Admin/ManageUsers/Edit.cshtml", aspNetUser);
        }

        // GET: ManageUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.Get(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/Admin/ManageUsers/Delete.cshtml", aspNetUser);
        }

        // POST: ManageUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
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
