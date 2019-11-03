using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class Page
    {
        [Key]
        public int PageRowId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [Required]
        public System.Guid PageId { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength]
        public string Description { get; set; }
        [MaxLength]
        public string PageContent { get; set; }
        [MaxLength]
        public string Keywords { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsFrontPage { get; set; }
        public Guid? Parent { get; set; }
        public bool? ShowInList { get; set; }
        [MaxLength(25)]
        public string Slug { get; set; }
        public bool IsDeleted { get; set; }
    }
}
