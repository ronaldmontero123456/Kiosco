using Kiosco.Core.Entities;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kiosco.Infrastructure.Repositories
{
    public class VacantesRepository : BaseRepository<DbContext, Vacantes>, IVacantesRepository
    {
        public VacantesRepository(KioscoDbContext dbContext) : base(dbContext)
        {

        }
    }
}
