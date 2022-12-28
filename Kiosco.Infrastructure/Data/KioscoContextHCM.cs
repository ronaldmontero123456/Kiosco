using Kiosco.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kiosco.Infrastructure.Data
{
    public class KioscoContextHCM: DbContext
    {
        public KioscoContextHCM(DbContextOptions<KioscoContextHCM> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblResumenHoras>().HasKey(e => e.idResumenHoras);
            modelBuilder.Entity<vEmpleados>().HasKey(e => e.idEmpleado);
        }

        public DbSet<TblResumenHoras> TblResumenHoras { get; set; }
        public DbSet<vEmpleados> vEmpleados { get; set; }
    }
}
