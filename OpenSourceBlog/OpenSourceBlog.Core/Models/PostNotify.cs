using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class PostNotify
    {
        public int PostNotifyId { get; set; }
        public System.Guid BlogId { get; set; }
        public System.Guid PostId { get; set; }
        public string NotifyAddress { get; set; }
    }
}
