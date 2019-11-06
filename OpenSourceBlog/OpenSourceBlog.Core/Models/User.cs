using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OpenSourceBlog.Core.Models
{
    public class User
    {
        [Key]
        [Required]
        [MaxLength(128)]
        public string Id { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        [Required]
        public bool EmailConfirmed { get; set; }
        [MaxLength]
        public string PasswordHash { get; set; }
        [MaxLength]
        public string SecurityStamp { get; set; }
        [MaxLength]
        public string PhoneNumber { get; set; }
        [Required]
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        [Required]
        public DateTime? LockoutEndDateUtc { get; set; }
        [Required]
        public bool LockoutEnabled { get; set; }
        [Required]
        public int AccessFailedCount { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
