using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenSourceBlog.Models;
using Microsoft.AspNet.Identity;

namespace OpenSourceBlog.Controllers
{
    public class AdminController : Controller
    {

        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin
        public ActionResult ManageUsers()
        {
            return View();
        }
    }
}