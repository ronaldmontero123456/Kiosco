using Kiosco.Core.Entities;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kiosco.Infrastructure.Repositories
{
    public class TblResumenHorasRepository : BaseRepository<DbContext, TblResumenHoras>, ITblResumenHorasRepository
    {
        public TblResumenHorasRepository(KioscoContext context) : base(context) { }
    }
}
