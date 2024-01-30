using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecurityApp.Models;

namespace SecurityApp.Data
{
    public class SecurityAppDbContext : IdentityDbContext
    {
        public SecurityAppDbContext(DbContextOptions options) 
           : base(options)
        {
        }

        public DbSet<ApplicationUser> applicationUser { get; set; } 
    }
}
