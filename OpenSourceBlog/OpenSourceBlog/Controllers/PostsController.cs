using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenSourceBlog.Database;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;

namespace OpenSourceBlog.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        //private ApplicationContext db = new ApplicationContext();
        private PostRepository db = new PostRepository();

        // GET: Posts
        public ActionResult Index()
        {
            //return View(db.Posts.ToList());
            return View(db.GetAll());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Post post = db.Posts.Find(id);
            Post post = db.Get(Convert.ToInt32(id));
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostRowId,BlogId,PostId,Title,Description,PostContent,DateCreated,DateModified,Author,IsPublished,IsCommentEnabled,Raters,Rating,Slug,IsDeleted")] Post post)
        {
            if (ModelState.IsValid)
            {
                //db.Posts.Add(post);
                //db.SaveChanges();
                db.Create(post);
                return RedirectToAction("Index");
            }
            Post emptyPost = new Post()
            {
                BlogId = GlobalVars.BlogId,
                PostId = Guid.NewGuid()
            };
            ViewData["mypost"] = emptyPost;

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Post post = db.Posts.Find(id);
            Post post = db.Get(Convert.ToInt32(id));
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostRowId,BlogId,PostId,Title,Description,PostContent,DateCreated,DateModified,Author,IsPublished,IsCommentEnabled,Raters,Rating,Slug,IsDeleted")] Post post)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(post).State = EntityState.Modified;
                //db.SaveChanges();
                db.Update(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Post post = db.Posts.Find(id);
            Post post = db.Get(Convert.ToInt32(id));
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Post post = db.Posts.Find(id);
            //db.Posts.Remove(post);
            //db.SaveChanges();
            db.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
