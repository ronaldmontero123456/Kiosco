using Kiosco.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Infrastructure.Data
{
    public class KioscoDbContext : DbContext
    {
        public KioscoDbContext(DbContextOptions<KioscoDbContext> options) : base(options)   
        {
                
        }
        public DbSet<Vacantes> Vacantes { get; set; }
        public DbSet<VacantesRequisitos> VacantesRequisitos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacantes>().HasKey(e => e.VacanteId);
            modelBuilder.Entity<VacantesRequisitos>().HasKey(e => e.VacantesRequisitosId);
        }
    }
}
