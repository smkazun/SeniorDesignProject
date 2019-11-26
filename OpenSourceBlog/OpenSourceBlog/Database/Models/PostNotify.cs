using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Database.Models
{
    public class PostNotify
    {
        [Key]
        [Required]
        public int PostNotifyId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [Required]
        public System.Guid PostId { get; set; }
        [MaxLength(255)]
        public string NotifyAddress { get; set; }
    }
}
