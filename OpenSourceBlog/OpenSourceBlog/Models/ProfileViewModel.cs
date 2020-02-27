using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Models
{
    public class ProfileViewModel
    {
        public AspNetUser user { get; set; }
        public Post post { get; set; }
    }
}