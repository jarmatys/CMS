﻿using CMS.Models.Db.Account;
using CMS.Models.Db.Admin;
using CMS.Models.Db.Article;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Context
{
    public class CMSContext : IdentityDbContext<User>
    {
        public CMSContext(DbContextOptions<CMSContext> options) : base (options) { }

        // Tutaj będziemy dodawać DbSet'y
        public DbSet<OptionsModel> Options { get; set; }
        public DbSet<PostModel> Posts { get; set; }

        // Zaślepka na klasę bazową
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}