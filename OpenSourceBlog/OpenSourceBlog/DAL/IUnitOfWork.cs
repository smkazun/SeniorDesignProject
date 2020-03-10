using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceBlog.DAL
{
    public interface IUnitOfWork
    {
        void Save();
        void Dispose();

        IGenericRepository<Blog, int> _blogRepository { get; }
        IGenericRepository<Category, int> _categoryRepository { get; }

        IGenericRepository<Page, int> _pageRepository { get; }
        IGenericRepository<PostCategory, int> _postCategoryRepository { get; }
        IGenericRepository<PostComment, int> _postCommentRepository { get; }
        IGenericRepository<PostNotify, int> _postNotifyRepository { get; }
        IGenericRepository<Post, int> _postRepository { get; }
        IGenericRepository<PostTag, int> _postTagRepository { get; }
        IGenericRepository<Profile, int> _profileRepository { get; }
        IGenericRepository<Right, int> _rightRepository { get; }
        IGenericRepository<RightRole, int> _rightRoleRepository { get; }
        IGenericRepository<AspNetRole, string> _roleRepository { get; }
        IGenericRepository<Setting, int> _settingRepository { get; }
        IGenericRepository<StopWord, int> _stopWordRepository { get; }
        IGenericRepository<AspNetUser, string> _userRepository { get; }
        IGenericRepository<AspNetUserRole, string> _userRoleRepository { get; }


    }
}
