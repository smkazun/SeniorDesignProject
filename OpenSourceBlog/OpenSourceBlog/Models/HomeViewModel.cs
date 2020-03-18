using OpenSourceBlog.Database.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSourceBlog.Models
{
    public class HomeViewModel
    {
        public IPagedList<Post> Post { get; set; }
        public List<Setting> Setting { get; set; }
    }
}