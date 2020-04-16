using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Models
{
    public class BlogSetupViewModel
    {

        [Display(Name = "Blog Title")]
        public string BlogTitle { get; set; }

        [Display(Name = "Blog Description")]
        public string BlogDescription { get; set; }

        public List<Setting> settings { get; set; }
    }
}