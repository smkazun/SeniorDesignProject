using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Database.Models
{
    public class PostCategory
    {
        [Key]
        public int PostCategoryId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [Required]
        public System.Guid PostId { get; set; }
        [Required]
        public System.Guid CategoryId { get; set; }
    }
}
