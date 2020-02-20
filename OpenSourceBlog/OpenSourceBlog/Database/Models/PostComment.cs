using System;
using System.ComponentModel.DataAnnotations;

namespace OpenSourceBlog.Database.Models
{
    public class PostComment
    {
        [Key]
        public int PostCommentRowId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [Required]
        public System.Guid PostCommentId { get; set; }
        [Required]
        public System.Guid PostId { get; set; }
        [Required]
        public System.Guid ParentCommentId { get; set; }
        [Required]
        public System.DateTime CommentDate { get; set; }
        [MaxLength(255)]
        public string Author { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Website { get; set; }
        [MaxLength(50)]
        public string Comment { get; set; }
        [MaxLength(255)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string IP { get; set; }
        public bool? IsApproved { get; set; }
        [MaxLength(100)]
        public string ModeratedBy { get; set; }
        [MaxLength(255)]
        public string Avatar { get; set; }
        [Required]
        public bool IsSpam { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
