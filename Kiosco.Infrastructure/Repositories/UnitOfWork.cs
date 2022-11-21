using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
        private readonly KioscoDbContext _KioscoDbcontext;
        private readonly TblResumenHorasRepository _tblResumenHorasRepository;
        private readonly vEmpleadosRepository _vEmpleadosRepository;
        private readonly DynamicFormsRepository dynamicFormsRepository;
        private readonly LoginRepository _LoginRepository;
        private readonly VacantesRepository _VacantesRepository;

        public UnitOfWork(KioscoContext context, KioscoDbContext kioscoDbcontext)
        {
            _context = context;
            _KioscoDbcontext = kioscoDbcontext;
        }

        public ITblResumenHorasRepository TblResumenHorasRepository => _tblResumenHorasRepository ?? new TblResumenHorasRepository(_context);

        public IvEmpleadosRepository vEmpleadosRepository => _vEmpleadosRepository ?? new vEmpleadosRepository(_context);
        public ILoginRepository LoginRepository => _LoginRepository ?? new LoginRepository(_context);

        public IDynamicFormsRepository DynamicFormsRepository => dynamicFormsRepository ?? new DynamicFormsRepository(_context);

        public IVacantesRepository VacantesRepository => _VacantesRepository?? new VacantesRepository(_KioscoDbcontext);

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
