using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OpenSourceBlog.Core.Models
{
    public class Post
    {
        [Key]
        [Required]
        public int PostRowId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [Required]
        public System.Guid PostId { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string PostContent { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        [MaxLength(50)]
        public string Author { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsCommentEnabled { get; set; }
        public int? Raters { get; set; }
        public float? Rating { get; set; }
        [MaxLength(255)]
        public string Slug { get; set; }
        public bool IsDeleted { get; set; }
    }
}
