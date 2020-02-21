using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface ISettingRepository
    {
        IEnumerable<Setting> GetAll();
        Setting Get(int id);
        void Create(Setting entity);
        void Update(Setting entity);
        void Delete(int id);
    }
}
