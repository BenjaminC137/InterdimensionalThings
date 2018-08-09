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
        public DbSet<Thing> Things { get; set; }
        public DbSet<ThingCategory> ThingCategory { get; set; }
        public DbSet<ThingCart> ThingCarts { get; set; }
        public DbSet<ThingCartThing> ThingCartThings { get; set; }

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

            builder.Entity<Thing>().Property<decimal?>("Price").HasColumnType("decimal(18,2)");

            //builder.Entity<ThingCategory>().HasKey("Name"); // This isn't as good in case 'Name' doesn't exist
            builder.Entity<ThingCategory>().HasKey(x => x.Name);

            builder.Entity<ThingCategory>().Property(x => x.DateCreated).HasDefaultValueSql("Now(6)");
            builder.Entity<ThingCategory>().Property(x => x.DateLastModified).HasDefaultValueSql("Now(6)");
            builder.Entity<ThingCategory>().Property(x => x.Name).HasMaxLength(100);

            builder.Entity<ApplicationUser>()
                .HasOne(x => x.ThingCart)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey<ThingCart>(x => x.ApplicationUserID);        

        }
    }
}
