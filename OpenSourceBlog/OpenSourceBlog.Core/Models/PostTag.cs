using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class PostTag
    {
        public int PostTagID { get; set; }
        public System.Guid BlogID { get; set; }
        public System.Guid PostID { get; set; }
        public string Tag { get; set; }
    }
}
