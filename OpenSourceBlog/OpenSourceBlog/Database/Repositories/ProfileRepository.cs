﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationContext ctx = new ApplicationContext();
        public IEnumerable<Profile> GetAll()
        {
            return ctx.Profiles.ToList();
        }

        public Profile Get(string id)
        {
            return ctx.Profiles.Find(id);
        }

        public void Create(Profile entity)
        {
            ctx.Profiles.Add(entity);
        }

        public void Update(Profile entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(string id)
        {
            Profile p = Get(id);
            ctx.Profiles.Remove(p);
            ctx.SaveChanges();
        }
    }
}
