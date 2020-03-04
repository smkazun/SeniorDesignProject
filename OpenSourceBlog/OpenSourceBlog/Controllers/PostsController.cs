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
    public class PostsController : Controller
    {
        //private IGenericRepository<Post, int> repo;
        private UnitOfWork _unitOfWork;

        public PostsController() { }

        public PostsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "Administrators,Editors")]
        // GET: Posts
        public ActionResult Index()
        {
            return View("~/Views/Admin/PostIndex.cshtml", _unitOfWork._postRepository.GetAll());
        }
        [Authorize(Roles = "Administrators,Editors")]
        // GET: Posts
        public ActionResult PartialIndex()
        {
            return PartialView("~/Views/Admin/Posts/Index.cshtml", _unitOfWork._postRepository.GetAll());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Post post = db.Posts.Find(id);
            Post post = _unitOfWork._postRepository.Get(Convert.ToInt32(id));
            if (post == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Posts/Details.cshtml",post);
        }

        // GET: Posts/Create
        [Authorize(Roles = "Administrators,Editors")]
        public ActionResult Create()
        {
            return PartialView("~/Views/Admin/Posts/Create.cshtml");
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrators,Editors")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostRowId,BlogId,PostId,Title,Description,PostContent,DateCreated,DateModified,Author,IsPublished,IsCommentEnabled,Raters,Rating,Slug,IsDeleted")] Post post)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork._postRepository.Create(post);
                _unitOfWork.Save();
                 return RedirectToAction("Index");
            }
            Post emptyPost = new Post()
            {
                BlogId = GlobalVars.BlogId,
                PostId = Guid.NewGuid()
            };
            ViewData["mypost"] = emptyPost;

            return View("~/Views/Admin/Posts/Create.cshtml", post);
        }

        // GET: Posts/Edit/5
        [Authorize(Roles = "Administrators,Editors")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Post post = db.Posts.Find(id);
            Post post = _unitOfWork._postRepository.Get(Convert.ToInt32(id));
            if (post == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Posts/Edit.cshtml", post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrators,Editors")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostRowId,BlogId,PostId,Title,Description,PostContent,DateCreated,DateModified,Author,IsPublished,IsCommentEnabled,Raters,Rating,Slug,IsDeleted")] Post post)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork._postRepository.Update(post);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View("~/Views/Admin/Posts/Edit.cshtml", post);
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = "Administrators,Editors")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _unitOfWork._postRepository.Get(Convert.ToInt32(id));
            if (post == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Posts/Delete.cshtml", post);
        }

        // POST: Posts/Delete/5
        [Authorize(Roles = "Administrators,Editors")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitOfWork._postRepository.Delete(id);
            _unitOfWork.Save();
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
