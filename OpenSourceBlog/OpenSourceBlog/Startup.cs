﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using OpenSourceBlog.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenSourceBlog.Startup))]
namespace OpenSourceBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        // In this method we will create default User roles and Admin user for login 
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // creating first Admin Role and creating a default Admin User if none exist 
            if (!roleManager.RoleExists("Admin"))
            {

                //create admin role
                //var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                //role.Name = "Admin";
                //roleManager.Create(role);

                //create defualt admin superuser                 
                var user = new ApplicationUser();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";
                
                string userPWD = "Admin1@";
                
                var checkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin 
                if (checkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

        }
    }
}
