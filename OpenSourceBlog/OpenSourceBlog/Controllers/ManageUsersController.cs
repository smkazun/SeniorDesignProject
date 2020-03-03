using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Models;

namespace OpenSourceBlog.Controllers
{
    public class ManageUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IUserRepository db;

        public ManageUsersController(IUserRepository db, IUserStore<ApplicationUser> userStore)
        {
            this.db = db;
            _userManager = new UserManager<ApplicationUser>(userStore);
        }

        // GET: ManageUsers
        public ActionResult Index()
        {
            List<AspNetUser> users = (List<AspNetUser>)db.GetAll();
            List<ManageUsersViewModel> model = new List<ManageUsersViewModel>();

            //Loop through ALL users
            for (int i = 0; i < users.Count; i++)
            {
                ManageUsersViewModel u = new ManageUsersViewModel();
                AspNetUser user = users[i];
                u.User = user;
                u.Role = db.GetRole(users[i].Id).Name;
                u.IsChecked = false;

                model.Add(u);
            }
            return View("~/Views/Admin/ManageUsers/Index.cshtml", model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(FormCollection formCollection)
        {
            string[] ids = formCollection["ID"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var user = await _userManager.FindByIdAsync(id);
                var logins = user.Logins;
                var rolesForUser = await _userManager.GetRolesAsync(id);
                foreach (var login in logins.ToList())
                {
                    await _userManager.RemoveLoginAsync(login.UserId,
                        new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                }

                if (rolesForUser.ToList().Count > 0)
                {
                    foreach (var role in rolesForUser.ToList())
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user.Id, role);
                    }
                }

                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        // GET: ManageUsers
        public ActionResult PartialIndex()
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
                u.IsChecked = false;

                model.Add(u);
            }
            return PartialView("~/Views/Admin/ManageUsers/Index.cshtml", model);
        }

        // GET: ManageUsers/Details/5
        // public ActionResult Details(string id)
        // {
        //     if (id == null)
        //     {
        //         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //     }
        //     AspNetUser aspNetUser = db.Get(id);
        //     if (aspNetUser == null)
        //     {
        //         return HttpNotFound();
        //     }
        //     return View("~/Views/Admin/ManageUsers/Details.cshtml", aspNetUser);
        // }

        // GET: ManageUsers/Create
        // public ActionResult Create()
        // {
        //     return View("~/Views/Admin/ManageUsers/Create.cshtml");
        // }

        // POST: ManageUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] AspNetUser aspNetUser)
        // {
        //     ManageUsersViewModel model = new ManageUsersViewModel()
        //     {
        //         User = aspNetUser,
        //         Role = db.GetRole(aspNetUser.Id).Name
        //     };
        //
        //     if (ModelState.IsValid)
        //     {
        //         // db.Create(aspNetUser);
        //         //ToDo Create a user and role using rolemanage/usermanager
        //         return RedirectToAction("Index");
        //     }
        //
        //     return View("~/Views/Admin/ManageUsers/Create.cshtml", model);
        // }

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
            return View("~/Views/Admin/ManageUsers/Edit.cshtml", model);
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
            return View("~/Views/Admin/ManageUsers/Edit.cshtml", model);
        }

        // GET: ManageUsers/Delete/5
        public ActionResult Delete(IEnumerable<ManageUsersViewModel> users)
        {
            // if (id == null)
            // {
            //     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            // }
            // AspNetUser aspNetUser = db.Get(id);
            ManageUsersViewModel model = new ManageUsersViewModel();
            foreach (var m in users)
            {
                Boolean isChecked = m.IsChecked;
                AspNetUser user = m.User;
                string role = m.Role;

                model.User = user;
                model.IsChecked = isChecked;
                model.Role = role;
            }
            
            if (model.User == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        // POST: ManageUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(IEnumerable<ManageUsersViewModel> model)
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
