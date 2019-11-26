using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OpenSourceBlog.Database.Models
{
    public partial class Blog
    {
        [Key]
        [Required]
        public int BlogRowId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [MaxLength(255)]
        [Required]
        public string BlogName { get; set; }
        [MaxLength(255)]
        [Required]
        public string Hostname { get; set; }
        [Required]
        public bool IsAnyTextBeforeHostnameAccepted { get; set; }
        [MaxLength(255)]
        [Required]
        public string StorageContainerName { get; set; }
        [MaxLength(255)]
        [Required]
        public string VirtualPath { get; set; }
        [Required]
        public bool IsPrimary { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsSiteAggregation { get; set; }
    }
}
