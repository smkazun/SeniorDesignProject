using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public System.Guid BlogId { get; set; }
        public string UserName { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
    }
}
