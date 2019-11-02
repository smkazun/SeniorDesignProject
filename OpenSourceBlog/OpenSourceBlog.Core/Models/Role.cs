using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class Role
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual Role AspNetRole { get; set; }
    }
}
