using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ITblResumenHorasRepository TblResumenHorasRepository { get; }
        public IDynamicFormsRepository DynamicFormsRepository { get; }
        public IvEmpleadosRepository vEmpleadosRepository { get; }
        public ILoginRepository LoginRepository { get; }
        Task SaveChangesAsync();
    }
}
