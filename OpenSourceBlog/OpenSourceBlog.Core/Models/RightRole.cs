using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class RightRole
    {
        public int RightRoleRowId { get; set; }
        public System.Guid BlogId { get; set; }
        public string RightName { get; set; }
        public string Role { get; set; }
    }
}
