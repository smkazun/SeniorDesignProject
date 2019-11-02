using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class Post
    {
        public int PostRowID { get; set; }
        public System.Guid BlogID { get; set; }
        public System.Guid PostID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostContent { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string Author { get; set; }
        public Nullable<bool> IsPublished { get; set; }
        public Nullable<bool> IsCommentEnabled { get; set; }
        public Nullable<int> Raters { get; set; }
        public Nullable<float> Rating { get; set; }
        public string Slug { get; set; }
        public bool IsDeleted { get; set; }
    }
}
