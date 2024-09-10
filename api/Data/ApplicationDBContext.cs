using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }


        public DbSet<Category> Category { get; set; }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "ADMIN",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "USER",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}