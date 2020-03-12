using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSourceBlog.Database.Repositories
{
    public class SettingsRepository : GenericRepository<Setting, int>, ISettingsRepository
    {
        public SettingsRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Setting> GetSettings()
        {
            //AsNoTracking()
            return _ctx.Settings.Where(x => x.BlogId == GlobalVars.BlogId).ToList();
        }

    }
}