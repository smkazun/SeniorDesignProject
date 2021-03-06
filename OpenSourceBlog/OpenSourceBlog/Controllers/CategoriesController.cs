﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenSourceBlog.DAL;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Models;

namespace OpenSourceBlog.Controllers
{
    [Authorize(Roles = "Administrators,Editors")]
    public class CategoriesController : Controller
    {
        //        private ApplicationDbContext db = new ApplicationDbContext();
        //private IGenericRepository<Category, int> repo;
        private UnitOfWork _unitOfWork;

        public CategoriesController(UnitOfWork unitOfWork)
        {
            //this.repo = db;
            this._unitOfWork = unitOfWork;
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View(_unitOfWork._categoryRepository.GetAll());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _unitOfWork._categoryRepository.Get(Convert.ToInt32(id));
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
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
                _unitOfWork._categoryRepository.Create(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _unitOfWork._categoryRepository.Get(Convert.ToInt32(id));
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
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
                _unitOfWork._categoryRepository.Update(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _unitOfWork._categoryRepository.Get(Convert.ToInt32(id));
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitOfWork._categoryRepository.Delete(id);
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
