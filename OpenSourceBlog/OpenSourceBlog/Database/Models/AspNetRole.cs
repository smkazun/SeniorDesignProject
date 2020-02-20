using System.ComponentModel.DataAnnotations;

namespace OpenSourceBlog.Database.Models
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
