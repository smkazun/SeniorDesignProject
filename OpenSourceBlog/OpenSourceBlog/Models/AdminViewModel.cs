using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSourceBlog.Models
{
    public class AdminViewModel
    {
    }

    public class ManageUsersViewModel
    {
        public int Id { get; }

        public string Email { get; }

        public string UserName { get; }

        public string Role { get; }
    }
}