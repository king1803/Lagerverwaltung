using Lagerverwaltung.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SSG_Lagerverwaltung.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Ware> Ware { get; set; }
        public DbSet<Lagerplatz> Lagerplatz { get; set; }

        
    }
}
