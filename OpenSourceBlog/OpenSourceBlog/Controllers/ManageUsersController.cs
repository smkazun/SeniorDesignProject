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
using OpenSourceBlog.Database.Repositories;
using OpenSourceBlog.Models;

namespace OpenSourceBlog.Controllers
{
    public class ManageUsersController : Controller
    {
        private IGenericRepository<AspNetUser, string> userRepo;
        private IGenericRepository<AspNetUserRole, string> userRoleRepo;
        private IGenericRepository<AspNetRole, string> roleRepo;

        public ManageUsersController()
        {
            this.userRepo = new GenericRepository<AspNetUser, string>();
            this.userRoleRepo = new GenericRepository<AspNetUserRole, string>();
            this.roleRepo = new GenericRepository<AspNetRole, string>();
        }

        public ManageUsersController(IGenericRepository<AspNetUser, string> db, IGenericRepository<AspNetUserRole, string> db2, IGenericRepository<AspNetRole, string> db3)
        {
            this.userRepo = db;
            this.userRoleRepo = db2;
            this.roleRepo = db3;
        }

        // GET: ManageUsers
        public ActionResult Index()
        {
            List<AspNetUser> users = (List<AspNetUser>)userRepo.GetAll();
            List<ManageUsersViewModel> model = new List<ManageUsersViewModel>();

            //Loop through ALL users
            for (int i = 0; i < users.Count; i++)
            {
                ManageUsersViewModel u = new ManageUsersViewModel();
                AspNetUser user = users[i];
                u.User = user;

                AspNetUserRole userRole = userRoleRepo.Get(users[i].Id);
                string roleId = userRole.RoleId;
                u.Role = roleRepo.Get(roleId).Name;
                
                u.IsChecked = false;

                model.Add(u);
            }
            return View("~/Views/Admin/ManageUsers/Index.cshtml", model);
        }

        // GET: ManageUsers
        public ActionResult PartialIndex()
        {
            List<AspNetUser> users = (List<AspNetUser>) userRepo.GetAll();
            List<ManageUsersViewModel> model = new List<ManageUsersViewModel>();

            //Loop through ALL users
            for (int i = 0; i < users.Count; i++)
            {
                ManageUsersViewModel u = new ManageUsersViewModel();
                AspNetUser user = users[i];
                u.User = user;

                AspNetUserRole userRole = userRoleRepo.Get(users[i].Id);
                string roleId = userRole.RoleId;
                u.Role = roleRepo.Get(roleId).Name;
                
                u.IsChecked = false;

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
            AspNetUser aspNetUser = userRepo.Get(id);
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
            AspNetUserRole userRole = userRoleRepo.Get(aspNetUser.Id);
            string roleId = userRole.RoleId;

            ManageUsersViewModel model = new ManageUsersViewModel()
            {
                User = aspNetUser,
                Role = roleRepo.Get(roleId).Name
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
            AspNetUser aspNetUser = userRepo.Get(id);

            AspNetUserRole userRole = userRoleRepo.Get(id);
            string roleId = userRole.RoleId;

            ManageUsersViewModel model = new ManageUsersViewModel()
            {
                User = aspNetUser,
                Role = roleRepo.Get(roleId).Name
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
        public ActionResult Edit(ManageUsersViewModel model)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (ModelState.IsValid)
            {
                //ToDo Edit the user/role using role/user manager

                //Remove user from ALL current roles
                List<string> roles = userManager.GetRoles(model.User.Id).ToList();
                for(int i = 0; i < roles.Count; i++)
                {
                    userManager.RemoveFromRole(model.User.Id, roles[i]);
                }
                //Add user to new selected role
                userManager.AddToRole(model.User.Id, model.Role);

                return Index();
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
            AspNetUser aspNetUser = userRepo.Get(id);

            AspNetUserRole userRole = userRoleRepo.Get(id);
            string roleId = userRole.RoleId;

            ManageUsersViewModel model = new ManageUsersViewModel()
            {
                User = aspNetUser,
                Role = roleRepo.Get(roleId).Name
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
