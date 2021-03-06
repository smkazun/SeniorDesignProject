﻿using OpenSourceBlog.Database;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace OpenSourceBlog.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context;

        public IGenericRepository<Blog, int> _blogRepository => new GenericRepository<Blog, int>(_context);
        public IGenericRepository<Category, int> _categoryRepository => new GenericRepository<Category, int>(_context);

        public IGenericRepository<Page, int> _pageRepository => new GenericRepository<Page, int>(_context);
        public IGenericRepository<PostCategory, int> _postCategoryRepository => new GenericRepository<PostCategory, int>(_context);
        public IGenericRepository<PostComment, int> _postCommentRepository => new GenericRepository<PostComment, int>(_context);
        public IGenericRepository<PostNotify, int> _postNotifyRepository => new GenericRepository<PostNotify, int>(_context);
        public IPostRepository _postRepository => new PostRepository(_context);
        public IGenericRepository<PostTags, int> _postTagRepository => new GenericRepository<PostTags, int>(_context);
        public IGenericRepository<Profile, int> _profileRepository => new GenericRepository<Profile, int>(_context);
        public IGenericRepository<Right, int> _rightRepository => new GenericRepository<Right, int>(_context);
        public IGenericRepository<RightRole, int> _rightRoleRepository => new GenericRepository<RightRole, int>(_context);
        public IGenericRepository<AspNetRole, string> _roleRepository => new GenericRepository<AspNetRole, string>(_context);
        public ISettingsRepository _settingsRepository => new SettingsRepository(_context);
        public IGenericRepository<StopWord, int> _stopWordRepository => new GenericRepository<StopWord, int>(_context);
        public IGenericRepository<AspNetUser, string> _userRepository => new GenericRepository<AspNetUser, string>(_context);
        public IGenericRepository<AspNetUserRole, string> _userRoleRepository => new GenericRepository<AspNetUserRole, string>(_context);

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }
        public UnitOfWork()
        {
            _context = new ApplicationContext();
        }


        public void Save()
        {

            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    // Update the values of the entity that failed to save from the store
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}