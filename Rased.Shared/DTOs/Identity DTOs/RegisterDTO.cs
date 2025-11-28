using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rased.Shared.DTOs.Identity_DTOs
{
    public record RegisterDTO(string Email, string FullName, string UserName, string Password, [Phone] string PhoneNumber);

}
