using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class Blog
    {
        public int BlogRowID { get; set; }
        public System.Guid BlogID { get; set; }
        public string BlogName { get; set; }
        public string Hostname { get; set; }
        public bool IsAnyTextBeforeHostnameAccepted { get; set; }
        public string StorageContainerName { get; set; }
        public string VirtualPath { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
        public bool IsSiteAggregation { get; set; }
    }
}
