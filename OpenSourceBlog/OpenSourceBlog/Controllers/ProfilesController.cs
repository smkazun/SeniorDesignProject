using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenSourceBlog.DAL;
using OpenSourceBlog.Database;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;

namespace OpenSourceBlog.Controllers
{
    public class ProfilesController : Controller
    {
        private IProfileRepository profiledb;
        private IUserRepository userdb;
        private IPostRepository postdb;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<Profile> all;

        public ProfilesController() { }
        public ProfilesController(IProfileRepository profiledb, IUserRepository userdb, IPostRepository postdb)
        {
            this.profiledb = profiledb;
            this.userdb = userdb;
            this.postdb = postdb;
        }

        public ProfilesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Profiles
        public ActionResult Index()
        {
            List<Post> posts = (List<Post>)postdb.GetAll();
            AspNetUser user = (AspNetUser)User.Identity;
            return View("~/Views/Profiles/Index.cshtml");
        }

        // GET: Profiles/Details/5
        [HttpGet]
        public ActionResult Details(int? id)//string name
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Profile profile = db.Get(id);
            //int id = getProfileId(name);
            Profile profile = _unitOfWork._profileRepository.Get(Convert.ToInt32(id));
                System.Diagnostics.Debug.WriteLine(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View("Details", profile);
        }

        //Helper for details
        private int getProfileId(string name)
        {
            int id = 0;
            all = _unitOfWork._profileRepository.GetAll();
            for (int i = 0; i < all.Count(); i++)
                if (all.ElementAt(i).SettingName.Equals(name, StringComparison.OrdinalIgnoreCase))
                    id = all.ElementAt(i).ProfileId;
            return id;
        }

        // GET: Profiles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Profile profile = _unitOfWork._profileRepository.Get(Convert.ToInt32(id));
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Profiles/Details.cshtml", profile);
        }
        
        /*// GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfileId,BlogId,UserName,SettingName,SettingValue")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }


        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfileId,BlogId,UserName,SettingName,SettingValue")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
