using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class AspNetRole
    {
        [Key]
        [Required]
        [MaxLength(128)]
        public string Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
    }
}
