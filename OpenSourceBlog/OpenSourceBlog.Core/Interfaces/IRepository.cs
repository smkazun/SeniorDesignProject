using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.Core.Interfaces
{
    public interface IRepository<T, U> where T :class
    {
        IEnumerable<T> GetAll();
        T Get(U id);
        void Create(T entity);
        void Update(U id, T entityNew);
        void Delete(U id);
    }
}
