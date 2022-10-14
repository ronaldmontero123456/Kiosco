using Kiosco.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kiosco.Infrastructure.Data
{
    public class KioscoContext : DbContext
    {
        public KioscoContext(DbContextOptions<KioscoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblResumenHoras>().HasKey(e => e.idResumenHoras);
            modelBuilder.Entity<DynamicForms>().HasKey(e => e.FormID);
            modelBuilder.Entity<Empleados>().HasKey(e => e.EmpId);
        }
        public DbSet<TblResumenHoras> TblResumenHoras { get; set; }
        public DbSet<DynamicForms> DynamicForms { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
    }
}
