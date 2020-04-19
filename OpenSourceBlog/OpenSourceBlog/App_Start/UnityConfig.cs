using System;
using OpenSourceBlog.Controllers;
using OpenSourceBlog.DAL;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;
using OpenSourceBlog.Database.Repositories;
using Unity;
using Unity.Injection;

namespace OpenSourceBlog
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            //container.LoadConfiguration();


            
            // TODO: Register your type's mappings here.

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            //container.RegisterType<PostsController>(new InjectionConstructor());

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IGenericRepository<Blog, int>, GenericRepository<Blog, int>>();
            container.RegisterType<IGenericRepository<Category, int>, GenericRepository<Category, int>>();
            container.RegisterType<IGenericRepository<Page, int>, GenericRepository<Page, int>>();
            container.RegisterType<IGenericRepository<PostCategory, int>, GenericRepository<PostCategory, int>>();
            container.RegisterType<IGenericRepository<PostComment, int>, GenericRepository<PostComment, int>>();
            container.RegisterType<IGenericRepository<PostNotify, int>, GenericRepository<PostNotify, int>>();
            container.RegisterType<IGenericRepository<Post, int>, GenericRepository<Post, int>>();
            container.RegisterType<IGenericRepository<PostTags, int>, GenericRepository<PostTags, int>>();
            container.RegisterType<IGenericRepository<Profile, int>, GenericRepository<Profile, int>>();
            container.RegisterType<IGenericRepository<Right, int>, GenericRepository<Right, int>>();
            container.RegisterType<IGenericRepository<RightRole, int>, GenericRepository<RightRole, int>>();
            container.RegisterType<IGenericRepository<AspNetRole, string>, GenericRepository<AspNetRole, string>>();
            container.RegisterType<IGenericRepository<Setting, int>, GenericRepository<Setting, int>>();
            container.RegisterType<IGenericRepository<StopWord, int>, GenericRepository<StopWord, int>>();
            container.RegisterType<IGenericRepository<AspNetUser, string>, GenericRepository<AspNetUser, string>>();
            container.RegisterType<IGenericRepository<AspNetUserRole, string>, GenericRepository<AspNetUserRole, string>>();
            
        }
    }
}