﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class StopWord
    {
        public int StopWordRowId { get; set; }
        public System.Guid BlogId { get; set; }
        public string StopWord1 { get; set; }
    }
}
