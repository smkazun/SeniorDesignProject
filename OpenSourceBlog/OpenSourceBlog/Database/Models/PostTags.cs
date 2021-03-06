﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Database.Models
{
    public class PostTags
    {
        [Key]
        [Required]
        public int PostTagId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [Required]
        public System.Guid PostId { get; set; }
        [MaxLength(50)]
        public string Tag { get; set; }
    }
}
