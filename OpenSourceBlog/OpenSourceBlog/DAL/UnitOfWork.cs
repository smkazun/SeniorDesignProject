using OpenSourceBlog.Database;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSourceBlog.DAL
{
    public class UnitOfWork : IUnitOfWork 
    {
        private ApplicationContext _ctx;
        private Dictionary<Type, object> _repositories;

        
        public IGenericRepository<Blog, int> _blogRepository => new GenericRepository<Blog, int>(_ctx);
        public IGenericRepository<Category, int> _categoryRepository => new GenericRepository<Category, int>(_ctx);

        public IGenericRepository<Page, int> _pageRepository => new GenericRepository<Page, int>(_ctx);
        public IGenericRepository<PostCategory, int> _postCategoryRepository => new GenericRepository<PostCategory, int>(_ctx);
        public IGenericRepository<PostComment, int> _postCommentRepository => new GenericRepository<PostComment, int>(_ctx);
        public IGenericRepository<PostNotify, int> _postNotifyRepository => new GenericRepository<PostNotify, int>(_ctx);
        public IGenericRepository<Post, int> _postRepository => new GenericRepository<Post, int>(_ctx);
        public IGenericRepository<PostTag, int> _postTagRepository => new GenericRepository<PostTag, int>(_ctx);
        public IGenericRepository<Profile, int> _profileRepository => new GenericRepository<Profile, int>(_ctx);
        public IGenericRepository<Right, int> _rightRepository => new GenericRepository<Right, int>(_ctx);
        public IGenericRepository<RightRole, int> _rightRoleRepository => new GenericRepository<RightRole, int>(_ctx);
        public IGenericRepository<AspNetRole, string> _roleRepository => new GenericRepository<AspNetRole, string>(_ctx);
        public IGenericRepository<Setting, int> _settingRepository => new GenericRepository<Setting, int>(_ctx);
        public IGenericRepository<StopWord, int> _stopWordRepository => new GenericRepository<StopWord, int>(_ctx);
        public IGenericRepository<AspNetUser, string> _userRepository => new GenericRepository<AspNetUser, string>(_ctx);
        public IGenericRepository<AspNetUserRole, string> _userRoleRepository => new GenericRepository<AspNetUserRole, string>(_ctx);
        

        public UnitOfWork(ApplicationContext context)
        {
            _ctx = context;
            _repositories = new Dictionary<Type, object>();
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        /*
        public IGenericRepository<T, U> GetRepository()
        {
            // Checks if the Dictionary Key contains the Model class
            if (_repositories.Keys.Contains(typeof(T)))
            {
                // Return the repository for that Model class
                return _repositories[typeof(T)] as IGenericRepository<T, U>;
            }

            // If the repository for that Model class doesn't exist, create it
            var repository = new GenericRepository<T, U>(_ctx);

            // Add it to the dictionary
            _repositories.Add(typeof(T), repository);

            return repository;
        }
        */
    }
}