using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AppUser:IdentityUser<int>
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
    }
}
