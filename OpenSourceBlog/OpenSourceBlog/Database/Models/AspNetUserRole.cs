using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Database.Models
{
    public class AspNetUserRole
    {
        [Key]
        [Required]
        [MaxLength(128)]
        public string UserId { get; set; }
        [Required]
        [MaxLength(128)]
        public string RoleId { get; set; }
    }
}
