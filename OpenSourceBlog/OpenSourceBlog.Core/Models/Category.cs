using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Models
{
    public class Category
    {
        public int CategoryRowID { get; set; }
        public System.Guid BlogID { get; set; }
        public System.Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public Nullable<System.Guid> ParentID { get; set; }
    }
}
