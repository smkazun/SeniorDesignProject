using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IRightRepository
    {
        IEnumerable<Right> GetAll();
        Right Get(int id);
        void Create(Right entity);
        void Update(Right entity);
        void Delete(int id);
    }
}
