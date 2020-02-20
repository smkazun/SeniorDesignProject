using System.Collections.Generic;

namespace OpenSourceBlog.Database.Interfaces
{ 
    public interface IRepository<T, U> where T :class
    {
        IEnumerable<T> GetAll();
        T Get(U id);
        void Create(T entity);
        void Update(T entity);
        void Delete(U id);
    }
}
