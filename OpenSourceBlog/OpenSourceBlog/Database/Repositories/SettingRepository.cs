﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenSourceBlog.Database.Interfaces;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Database.Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private readonly ApplicationContext ctx = new ApplicationContext();

        public IEnumerable<Setting> GetAll()
        {
            return ctx.Settings.ToList();
        }

        public Setting Get(int id)
        {
            return ctx.Settings.Find(id);
        }

        public void Create(Setting entity)
        {
            ctx.Settings.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(Setting entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Setting s = Get(id);
            ctx.Settings.Remove(s);
            ctx.SaveChanges();
        }
    }
}
