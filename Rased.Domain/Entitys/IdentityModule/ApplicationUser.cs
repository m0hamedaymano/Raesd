using Microsoft.AspNetCore.Identity;
using Rased.Domain.Entitys.IdentityModule.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rased.Domain.Entitys.IdentityModule
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = default!;
        public string PlateNumber { get; set; } = default!;
        public UserTybe  UserTybe { get; set; } = default!;
        public int SSN { get; set; } = default!;


    }
}
