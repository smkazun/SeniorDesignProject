using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class RightRole
    {
        public int RightRoleRowID { get; set; }
        public System.Guid BlogID { get; set; }
        public string RightName { get; set; }
        public string Role { get; set; }
    }
}
