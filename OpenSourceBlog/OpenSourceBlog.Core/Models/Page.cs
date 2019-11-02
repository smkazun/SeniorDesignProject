using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class Page
    {
        public int PageRowID { get; set; }
        public System.Guid BlogID { get; set; }
        public System.Guid PageID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PageContent { get; set; }
        public string Keywords { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<bool> IsPublished { get; set; }
        public Nullable<bool> IsFrontPage { get; set; }
        public Nullable<System.Guid> Parent { get; set; }
        public Nullable<bool> ShowInList { get; set; }
        public string Slug { get; set; }
        public bool IsDeleted { get; set; }
    }
}
