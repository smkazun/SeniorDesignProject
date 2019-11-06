using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class Right
    {
        [Key]
        [Required]
        public int RightRowId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [Required]
        [MaxLength(100)]
        public string RightName { get; set; }
    }
}
