using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KioscoContext _context;
        private readonly TblResumenHorasRepository _tblResumenHorasRepository;
        private readonly vEmpleadosRepository _vEmpleadosRepository;
        private readonly DynamicFormsRepository dynamicFormsRepository;
        private readonly LoginRepository _LoginRepository;

        public UnitOfWork(KioscoContext context)
        {
            _context = context;
        }

        public ITblResumenHorasRepository TblResumenHorasRepository => _tblResumenHorasRepository ?? new TblResumenHorasRepository(_context);

        public IvEmpleadosRepository vEmpleadosRepository => _vEmpleadosRepository ?? new vEmpleadosRepository(_context);
        public ILoginRepository LoginRepository => _LoginRepository ?? new LoginRepository(_context);

        public IDynamicFormsRepository DynamicFormsRepository => dynamicFormsRepository ?? new DynamicFormsRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
