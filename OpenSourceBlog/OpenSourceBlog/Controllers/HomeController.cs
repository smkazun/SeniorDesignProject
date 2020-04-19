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
using System.Net;
using PagedList;
using OpenSourceBlog.Models;

namespace OpenSourceBlog.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public HomeController() 
        {
        }


        public HomeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //GET/POST
        //Displays the posts for this blog, with paging and searching
        public ActionResult Index(string searchString, string currentFilter, int? page)
        {
            themeSetter();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            
            var model = new HomeViewModel();

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


            int pageSize = pageSizeHelper();
            int pageNumber = (page ?? 1); //uses page value if non-null, otherwise 1

            model.Post = resultList.ToPagedList(pageNumber, pageSize);
            model.Setting = (List<Setting>) _unitOfWork._settingsRepository.GetSettings();
            TempData["Model"] = model;

            //populate viewdata
            foreach (var item in model.Setting)
            {
                if (item.SettingName.Equals("Blog Title"))
                {
                    ViewData["BlogTitle"] = item.SettingValue;
                }
                else if (item.SettingName.Equals("Blog Description"))
                {
                    ViewData["BlogDesc"] = item.SettingValue;
                }
            }

            return View(model);

        }

        //GET
        public ActionResult Archive()
        {
            themeSetter();
            List<Post> fullList = (List<Post>) _unitOfWork._postRepository.GetAll();
            List<Post> resultList = new List<Post>();
            for (int i = fullList.Count - 1; i > -1; i--)
                if (fullList[i].IsDeleted == true && fullList[i].BlogId == GlobalVars.BlogId)
                    resultList.Add(fullList[i]);

            return View("Archive", resultList);
        }

        public ActionResult About()
        {
            themeSetter();
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[Authorize]
        public ActionResult Contact()
        {
            themeSetter();
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult postSort(int? id)
        {
            themeSetter();
            int? page = 1;
            var model = (HomeViewModel) TempData["Model"];

            if (id == null)
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

            
            int pageSize = pageSizeHelper();
            int pageNumber = (page ?? 1);
            model.Post = sortedList.ToPagedList(pageNumber, pageSize);
            TempData.Keep();
            return View("Index", model);
        }


        //Helper Methods
        private int pageSizeHelper()
        {
            var settingList = (List<Setting>)_unitOfWork._settingsRepository.GetSettings();
            var setting = settingList[2];
            return Convert.ToInt32(setting.SettingValue);
        }
        private void themeSetter()
        {
            var settingList = (List<Setting>)_unitOfWork._settingsRepository.GetSettings();
            Session["theme"] = settingList[5].SettingValue;
        }


    }

}