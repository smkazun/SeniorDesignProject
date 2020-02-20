using System.Linq;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
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
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Administrators"))
            {
                //First time running application, create roles
                var admin = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                var editor = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                var user = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                admin.Name = "Administrators";
                roleManager.Create(admin);
                editor.Name = "Editors";
                roleManager.Create(editor);
                user.Name = "Users";
                roleManager.Create(user);
            }

            // creating first Admin Role and creating a default Admin User if none exist
            if (userManager.FindByEmail("admin@gmail.com") == null)
            {
                //create default admin superuser                 
                var user = new ApplicationUser();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";
                user.EmailConfirmed = true;

                string userPWD = "Admin1@";

                var checkUser = userManager.Create(user, userPWD);

                //Add default User to Role Admin 
                if (checkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Administrators");
                }
            }
        }
    }
}
