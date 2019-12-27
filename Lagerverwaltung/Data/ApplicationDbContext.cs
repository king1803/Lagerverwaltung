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
        public DbSet<Hersteller> Hersteller { get; set; }
        public DbSet<Kategorie> Kategorie { get; set; }
        public DbSet<Kostenstelle> Kostenstelle { get; set; }
        public DbSet<Lager> Lager { get; set; }
        public DbSet<Lieferant> Lieferant { get; set; }



    }
}
