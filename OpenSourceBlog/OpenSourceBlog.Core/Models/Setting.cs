﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class Setting
    {
        [Key]
        [Required]
        public int SettingRowId { get; set; }
        [Required]
        public System.Guid BlogId { get; set; }
        [Required]
        [MaxLength(50)]
        public string SettingName { get; set; }
        [MaxLength]
        public string SettingValue { get; set; }
    }
}
