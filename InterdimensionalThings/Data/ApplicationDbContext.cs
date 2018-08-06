using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InterdimensionalThings.Models;
using Microsoft.AspNetCore.Identity;

namespace InterdimensionalThings.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {

        DbSet<Thing> Things { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
            
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<IdentityUserLogin<int>>().Property<string>("LoginProvider").HasMaxLength(50);
            builder.Entity<IdentityUserLogin<int>>().Property<string>("ProviderKey").HasMaxLength(50);

        }
    }
   
}
