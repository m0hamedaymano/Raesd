using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rased.Domain.Entitys.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rased.Persistence.IdentityData.DbContext
{
    public class RasedIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public RasedIdentityDbContext(DbContextOptions<RasedIdentityDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");    
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");

        }
    }
}
