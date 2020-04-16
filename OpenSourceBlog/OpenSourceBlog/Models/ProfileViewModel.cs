using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenSourceBlog.Database.Models;
using PagedList;

namespace OpenSourceBlog.Models
{
    public class ProfileViewModel
    {
        public AspNetUser User { get; set; }
        public Profile Profile { get; set; }
        public IPagedList<Post> Post { get; set; }
    }
}