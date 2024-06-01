using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)  :base(options)
        {

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Solution> Solutions { get; set; }

    }
}
