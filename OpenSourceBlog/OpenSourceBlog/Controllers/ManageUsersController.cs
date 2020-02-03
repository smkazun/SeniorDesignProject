using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            List<AspNetUser> users = (List<AspNetUser>) db.GetAll();
            List<ManageUsersViewModel> model = new List<ManageUsersViewModel>();

            //Loop through ALL users
            for (int i = 0; i < users.Count; i++)
            {
                ManageUsersViewModel u = new ManageUsersViewModel();
                AspNetUser user = users[i];
                u.User = user;
                u.Role = db.GetRole(users[i].Id).Name;


                model.Add(u);
            }
            return PartialView("~/Views/Admin/ManageUsers/Index.cshtml", model);
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
            ManageUsersViewModel model = new ManageUsersViewModel()
            {
                User = aspNetUser,
                Role = db.GetRole(aspNetUser.Id).Name
            };

            if (ModelState.IsValid)
            {
                // db.Create(aspNetUser);
                //ToDo Create a user and role using rolemanage/usermanager
                return RedirectToAction("Index");
            }

            return PartialView("~/Views/Admin/ManageUsers/Create.cshtml", model);
        }

        // GET: ManageUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.Get(id);
            ManageUsersViewModel model = new ManageUsersViewModel()
            {
                User = aspNetUser,
                Role = db.GetRole(aspNetUser.Id).Name
            };

            if (model.User == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/Admin/ManageUsers/Edit.cshtml", model);
        }

        // POST: ManageUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] AspNetUser aspNetUser)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            ManageUsersViewModel model = new ManageUsersViewModel()
            {
                User = aspNetUser,
                Role = db.GetRole(aspNetUser.Id).Name
            };

            //ToDo Edit the user/role using role/user manager

            if (ModelState.IsValid)
            {
                db.Update(aspNetUser);
                return RedirectToAction("Index");
            }
            return PartialView("~/Views/Admin/ManageUsers/Edit.cshtml", model);
        }

        // GET: ManageUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.Get(id);
            ManageUsersViewModel model = new ManageUsersViewModel()
            {
                User = aspNetUser,
                Role = db.GetRole(id).Name
            };

            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/Admin/ManageUsers/Delete.cshtml", model);
        }

        // POST: ManageUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //ToDo delete the user using user manager
            // db.Delete(id);
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
