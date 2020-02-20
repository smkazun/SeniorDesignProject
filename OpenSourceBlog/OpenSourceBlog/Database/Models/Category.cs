using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Database.Models
{
    public class Category
    {
        [Key]
        public int CategoryRowId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [Required]
        public System.Guid CategoryId { get; set; }
        [MaxLength(50)]
        public string CategoryName { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public Guid? ParentId { get; set; }
    }
}
