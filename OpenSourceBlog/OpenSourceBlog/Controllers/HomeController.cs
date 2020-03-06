using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenSourceBlog.Database;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;
using OpenSourceBlog.DAL;

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

        public ActionResult Index()
        {
            
            List<Post> fullList = (List<Post>) _unitOfWork._postRepository.GetAll();
            List<Post> resultList = new List<Post>();

            //display published posts only
            for (int i = fullList.Count-1; i > -1; i--)
                if (fullList[i].IsPublished == true && fullList[i].BlogId == GlobalVars.BlogId)
                    resultList.Add(fullList[i]);
            //for (int i = 0; i < fullList.Count; i++)
            //    if (fullList[i].IsPublished == true)
            //        resultList.Add(fullList[i]);

            return View(resultList);
            //return View(db.Posts.ToList());
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
        public ActionResult postSort(int? id)
        {
            List<Post> unsortedList;
            List<Post> sortedList;
            switch (id)
            {
                case 1: //most recent
                    unsortedList = (List<Post>)_unitOfWork._postRepository.GetAll();
                    sortedList = unsortedList.OrderBy(x => x.DateCreated).Where(x => x.IsPublished == true).ToList();
                    break;
                case 2: //least recent
                    unsortedList = (List<Post>)_unitOfWork._postRepository.GetAll();
                    sortedList = unsortedList.OrderByDescending(x => x.DateCreated).Where(x => x.IsPublished == true).ToList();
                    break;
                case 3: //highest rated
                    unsortedList = (List<Post>)_unitOfWork._postRepository.GetAll();
                    sortedList = unsortedList.OrderByDescending(x => x.Rating).Where(x => x.IsPublished == true).ToList();
                    break;
                default: //most recent
                    unsortedList = (List<Post>)_unitOfWork._postRepository.GetAll();
                    sortedList = unsortedList.OrderBy(x => x.DateCreated).Where(x => x.IsPublished == true).ToList();
                    break;

            }

            return View("Index", sortedList);
        }


        /*
        [HttpGet]
        public ActionResult leastRecentSort()
        {
            List<Post> unsortedList = (List<Post>)_unitOfWork._postRepository.GetAll();
            List<Post> sortedList = unsortedList.OrderBy(x => x.DateCreated).Where(x => x.IsPublished == true).ToList();

            return View("Index", sortedList);
        }
        
        [HttpGet]
        public ActionResult mostRecentSort()
        {
            List<Post> unsortedList = (List<Post>)_unitOfWork._postRepository.GetAll();
            List<Post> sortedList = unsortedList.OrderByDescending(x => x.DateCreated).Where(x => x.IsPublished == true).ToList();
            
            return View("Index", sortedList);
        }

        [HttpGet]
        public ActionResult highestRatedSort()
        {
            List<Post> unsortedList = (List<Post>)_unitOfWork._postRepository.GetAll();
            List<Post> sortedList = unsortedList.OrderByDescending(x => x.Rating).Where(x => x.IsPublished == true).ToList();

            return View("Index", sortedList);
        }
        */

    }

}