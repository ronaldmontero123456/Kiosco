using Kiosco.Core.Entities;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kiosco.Infrastructure.Repositories
{
    public class vEmpleadosRepository : BaseRepository<DbContext, vEmpleados>, IvEmpleadosRepository
    {
        public vEmpleadosRepository(KioscoContextHCM context) : base(context) { }
    }
}
