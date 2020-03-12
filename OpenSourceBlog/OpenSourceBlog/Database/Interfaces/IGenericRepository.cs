using OpenSourceBlog.Database.Models;
using System;
using System.Collections.Generic;

namespace OpenSourceBlog.Database.Interfaces
{ 
    public interface IGenericRepository<T, U> where T :class 
                                              where U : IConvertible
    {   
        IEnumerable<T> GetAll();
        T Get(U id);
        void Create(T entity);
        void Update(T entity);
        void Delete(U id);

    }
}
