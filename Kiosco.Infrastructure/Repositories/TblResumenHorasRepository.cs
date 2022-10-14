using Kiosco.Core.Entities;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;

namespace Kiosco.Infrastructure.Repositories
{
    public class TblResumenHorasRepository : BaseRepository<TblResumenHoras>, ITblResumenHorasRepository
    {
        public TblResumenHorasRepository(KioscoContext context) : base(context) { }
    }
}
