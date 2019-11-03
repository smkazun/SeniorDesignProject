using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OpenSourceBlog.Core.Models
{
    public partial class Blog
    {
        [Required]
        [Key]
        public int BlogRowId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [MaxLength(255)]
        public string BlogName { get; set; }
        [MaxLength(255)]
        public string Hostname { get; set; }
        public bool IsAnyTextBeforeHostnameAccepted { get; set; }
        [MaxLength(255)]
        public string StorageContainerName { get; set; }
        [MaxLength(255)]
        public string VirtualPath { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
        public bool IsSiteAggregation { get; set; }
    }
}
