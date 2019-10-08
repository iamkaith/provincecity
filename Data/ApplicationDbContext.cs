using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProvinceCity.Models;

namespace ProvinceCity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<City>().Property(c => c.CityID).IsRequired();

            builder.Entity<Province>().Property(p => p.ProvinceCode).IsRequired();
            builder.Entity<Province>().Property(p => p.ProvinceCode).HasMaxLength(2);

            builder.Entity<Province>().ToTable("Province");
            builder.Entity<City>().ToTable("City");

            builder.Seed();
        }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
