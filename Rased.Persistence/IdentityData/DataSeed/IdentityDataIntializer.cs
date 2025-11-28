using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Rased.Domain.Entitys.IdentityModule;
using Rased.Domain.Interfaces;
using Rased.Persistence.IdentityData.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rased.Persistence.IdentityData.DataSeed
{
    public class IdentityDataIntializer : IDataIntializer
    {
      
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<IdentityDataIntializer> _logger;

        public IdentityDataIntializer(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,ILogger<IdentityDataIntializer> logger)
        {
           _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task InitializeAsync()
        {
            try
            {
                if (_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                }
                if (!_userManager.Users.Any())
                {
                    var user = new ApplicationUser
                    {
                        UserName = "admin",
                        Email = "admin@gmail.com"

                    };
                  
                    await _userManager.CreateAsync(user, "Admin");

                    await _userManager.AddToRoleAsync(user, "Admin");
                    await _userManager.AddToRoleAsync(user, "SuperAdmin");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error While Seeding Identity DataBase : Masage = {ex.Message}");
            }
        }
    }
}
