using CMS.Models.Db.Account;
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

        // Zaślepka na klasę bazową
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
