using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class Setting
    {
        public int SettingRowID { get; set; }
        public System.Guid BlogID { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
    }
}
