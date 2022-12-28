using Kiosco.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kiosco.Infrastructure.Data
{
    public class KioscoDbContext : DbContext
    {
        public KioscoDbContext(DbContextOptions<KioscoDbContext> options) : base(options)
        {

        }
        public DbSet<Vacantes> Vacantes { get; set; }
        public DbSet<VacantesRequisitos> VacantesRequisitos { get; set; }
        public DbSet<VacantesAplicar> VacantesAplicar { get; set; }
        public DbSet<DynamicForms> DynamicForms { get; set; }
        public DbSet<EncuestasInternas> EncuestasInternas { get; set; }
        public DbSet<EncuestasInternasDetalle> EncuestasInternasDetalle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacantes>().HasKey(e => e.VacanteId);
            modelBuilder.Entity<VacantesRequisitos>().HasKey(e => e.VacantesRequisitosId);
            modelBuilder.Entity<VacantesAplicar>().HasKey(e => e.Id);
            modelBuilder.Entity<EncuestasInternas>().HasKey(e => e.EncId);
            modelBuilder.Entity<EncuestasInternasDetalle>().HasKey(e => e.EncDetID);
            modelBuilder.Entity<DynamicForms>().HasKey(e => e.FormID);
        }
    }
}
