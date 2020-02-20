using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Interfaces
{
    public interface IStopWordRepository
    {
        IEnumerable<StopWord> GetAll();
        StopWord Get(int id);
        void Create(StopWord entity);
        void Update(StopWord entity);
        void Delete(int id);
    }
}
