﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenSourceBlog.Database;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;
using OpenSourceBlog.DAL;
using System.Net;
using PagedList;

namespace OpenSourceBlog.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork;

        public HomeController() 
        {
            //this.repo = new GenericRepository<Post, int>();
        }


        public HomeController(UnitOfWork unitOfWork)
        {
            //this.repo = db;
            this._unitOfWork = unitOfWork;
        }

        public ActionResult Index(string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var fullList =  _unitOfWork._postRepository.GetAll();
            List<Post> resultList = new List<Post>(); //TODO see if we can change List to inumerable

            //searching
            if (!String.IsNullOrEmpty(searchString))
            {
                fullList = fullList.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper()));
            }
           
            //display published posts only
            for (int i = fullList.Count()-1; i > -1; i--)
                if (fullList.ElementAt(i).IsPublished == true && fullList.ElementAt(i).BlogId == GlobalVars.BlogId)
                    resultList.Add(fullList.ElementAt(i));
            //for (int i = 0; i < fullList.Count; i++)
            //    if (fullList[i].IsPublished == true)
            //        resultList.Add(fullList[i]);

            //return View(resultList);

            int pageSize = 3; //TODO get from settings db
            int pageNumber = (page ?? 1);
            return View(resultList.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Archive()
        {
            List<Post> fullList = (List<Post>) _unitOfWork._postRepository.GetAll();
            List<Post> resultList = new List<Post>();
            for (int i = fullList.Count - 1; i > -1; i--)
                if (fullList[i].IsDeleted == true && fullList[i].BlogId == GlobalVars.BlogId)
                    resultList.Add(fullList[i]);

            return View(resultList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult postSort(int? id) //TODO might need to move into index method
        {
            int? page = 1; 

            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<Post> unsortedList = (List<Post>)_unitOfWork._postRepository.GetAll();
            List<Post> sortedList;
            switch (id)
            {
                case 1: //most recent
                    sortedList = unsortedList.OrderByDescending(x => x.DateCreated).Where(x => x.IsPublished == true).ToList();
                    break;
                case 2: //least recent
                    sortedList = unsortedList.OrderBy(x => x.DateCreated).Where(x => x.IsPublished == true).ToList();
                    break;
                case 3: //highest rated
                    sortedList = unsortedList.OrderByDescending(x => x.Rating).Where(x => x.IsPublished == true).ToList();
                    break;
                default: throw new ArgumentOutOfRangeException();
            }

            int pageSize = 3; //TODO get from settings db
            int pageNumber = (page ?? 1);
            return View("Index", sortedList.ToPagedList(pageNumber, pageSize));
        }

    }

}