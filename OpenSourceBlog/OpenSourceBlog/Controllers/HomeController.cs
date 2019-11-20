using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenSourceBlog.Core.Models;
using OpenSourceBlog.Infrastructure;


namespace OpenSourceBlog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        public ActionResult Index()
        {
            List<Post> fullList = db.Posts.ToList();
            List<Post> resultList = new List<Post>();

            //display published posts only
            for (int i = 0; i < fullList.Count; i++)
                if (fullList[i].IsPublished == true)
                    resultList.Add(fullList[i]);

            return View(resultList);
            //return View(db.Posts.ToList());
        }

        public ActionResult Archive()
        {
            ViewBag.Message = "Archived blog posts.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}