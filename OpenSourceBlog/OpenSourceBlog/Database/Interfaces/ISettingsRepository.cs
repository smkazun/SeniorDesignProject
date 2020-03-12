using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface ISettingsRepository : IGenericRepository<Setting, int>
    {
        IEnumerable<Setting> GetSettings();
    }
}
