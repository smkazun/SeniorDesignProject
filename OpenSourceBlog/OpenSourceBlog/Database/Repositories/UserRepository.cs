﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext ctx = new ApplicationContext();

        public IEnumerable<AspNetUser> GetAll()
        {
            return ctx.AspNetUsers.ToList();
        }

        public AspNetUser Get(string id)
        {
            return ctx.AspNetUsers.Find(id);
        }

        public void Create(AspNetUser user)
        {
            //ToDo Do it the right way
            throw new NotImplementedException();
        }

        public void Update(AspNetUser user)
        {
            //ToDo Update and change the old data to new data
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            //ToDo Do it the right way
            throw new NotImplementedException();
        }

        public AspNetUser FindByUserName(string username)
        {
            var user = (from r in ctx.AspNetUsers where r.UserName == username select r).FirstOrDefault();
            return user;
        }

        public AspNetRole GetRoleByUserName(string username)
        {
            AspNetUser user = FindByUserName(username);
            string userId = user.Id;
            AspNetUserRole userRole = ctx.AspNetUserRoles.Find(userId);
            string roleId = userRole.RoleId;
            AspNetRole role = ctx.AspNetRoles.Find(roleId);
            string roleName = role.Name;
            return role;
        }
    }
}
