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
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Controllers
{
    [Authorize(Roles = "Administrators,Editors")]
    public class PostTagsController : Controller
    {
        //private ApplicationContext db = new ApplicationContext();
        private UnitOfWork _unitOfWork;

        public PostTagsController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: PostTags
        public ActionResult Index()
        {
            return View(_unitOfWork._postTagRepository.GetAll());
        }

        // GET: PostTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostTags postTag = _unitOfWork._postTagRepository.Get(Convert.ToInt32(id));
            if (postTag == null)
            {
                return HttpNotFound();
            }
            return View(postTag);
        }

        // GET: PostTags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostTagId,BlogId,PostId,Tag")] PostTags postTag)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork._postTagRepository.Create(postTag);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(postTag);
        }

        // GET: PostTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PostTags postTag = _unitOfWork._postTagRepository.Get(Convert.ToInt32(id));
            if (postTag == null)
            {
                return HttpNotFound();
            }
            return View(postTag);
        }

        // POST: PostTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostTagId,BlogId,PostId,Tag")] PostTags postTag)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork._postTagRepository.Update(postTag);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(postTag);
        }

        // GET: PostTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostTags postTag = _unitOfWork._postTagRepository.Get(Convert.ToInt32(id));
            if (postTag == null)
            {
                return HttpNotFound();
            }
            return View(postTag);
        }

        // POST: PostTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitOfWork._postTagRepository.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
