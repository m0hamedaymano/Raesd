using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rased.Shared.DTOs.Identity_DTOs
{
    public record UserDTO(string Email, string DisplayName, string Token);

}
