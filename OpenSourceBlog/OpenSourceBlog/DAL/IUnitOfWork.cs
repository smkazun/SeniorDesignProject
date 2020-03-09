using System;

namespace OpenSourceBlog.DAL
{
    public interface IUnitOfWork
     
    {

        void Save();
        void Dispose();
    }
}