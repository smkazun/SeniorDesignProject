using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Database.Models
{
    public class Profile
    {
        [Key]
        [Required]
        public int ProfileId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(200)]
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
    }
}
