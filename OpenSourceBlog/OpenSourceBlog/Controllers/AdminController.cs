using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenSourceBlog.Models;
using Microsoft.AspNet.Identity;

namespace OpenSourceBlog.Controllers
{
    [Authorize(Roles = "Administrators,Editors")]
    public class AdminController : Controller
    {

        public AdminController()
        {

        }

        // GET: Admin Index Page
        public ActionResult Index()
        {
            return View();
        }


    }
}