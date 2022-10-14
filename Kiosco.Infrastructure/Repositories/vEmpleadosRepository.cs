using Kiosco.Core.Entities;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Infrastructure.Repositories
{
    public class vEmpleadosRepository : BaseRepository<vEmpleados>, IvEmpleadosRepository
    {
        public vEmpleadosRepository(KioscoContext context): base(context) {}
    }
}
