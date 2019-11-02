using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class PostComment
    {
        public int PostCommentRowID { get; set; }
        public System.Guid BlogID { get; set; }
        public System.Guid PostCommentID { get; set; }
        public System.Guid PostID { get; set; }
        public System.Guid ParentCommentID { get; set; }
        public System.DateTime CommentDate { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Comment { get; set; }
        public string Country { get; set; }
        public string IP { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string ModeratedBy { get; set; }
        public string Avatar { get; set; }
        public bool IsSpam { get; set; }
        public bool IsDeleted { get; set; }
    }
}
