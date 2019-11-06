using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class StopWord
    {
        [Key]
        [Required]
        public int StopWordRowId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [Required]
        [MaxLength(50)]
        public string StopWord1 { get; set; }
    }
}
