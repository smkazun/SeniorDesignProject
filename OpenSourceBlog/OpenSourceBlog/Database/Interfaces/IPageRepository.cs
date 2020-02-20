using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetAll();
        Page Get(int id);
        void Create(Page entity);
        void Update(Page entity);
        void Delete(int id);
    }
}
