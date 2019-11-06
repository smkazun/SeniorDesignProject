using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class RightRole
    {
        [Key]
        [Required]
        public int RightRoleRowId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [Required]
        [MaxLength(100)]
        public string RightName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Role { get; set; }
    }
}
