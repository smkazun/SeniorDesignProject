using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Models
{
    public class AdminViewModel
    {
    }

    public class ManageUsersViewModel
    {
        public AspNetUser User { get; set; }
        public string Role { get; set; }
        public Boolean IsChecked { get; set; }
    }
}