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
        private readonly KioscoContextHCM _KioscoContextHCM;
        private readonly TblResumenHorasRepository _tblResumenHorasRepository;
        private readonly vEmpleadosRepository _vEmpleadosRepository;
        private readonly DynamicFormsRepository dynamicFormsRepository;
        private readonly LoginRepository _LoginRepository;
        private readonly VacantesRepository _VacantesRepository;
        private readonly EncuestasInternasRepository _EncuestasInternasRepository;

        public UnitOfWork(KioscoContext context, KioscoDbContext kioscoDbcontext, KioscoContextHCM KioscoContextHCM)
        {
            _context = context;
            _KioscoDbcontext = kioscoDbcontext;
            _KioscoContextHCM = KioscoContextHCM;
        }

        public ITblResumenHorasRepository TblResumenHorasRepository => _tblResumenHorasRepository ?? new TblResumenHorasRepository(_KioscoContextHCM);

        public IvEmpleadosRepository vEmpleadosRepository => _vEmpleadosRepository ?? new vEmpleadosRepository(_KioscoContextHCM);
        public ILoginRepository LoginRepository => _LoginRepository ?? new LoginRepository(_context);

        public IDynamicFormsRepository DynamicFormsRepository => dynamicFormsRepository ?? new DynamicFormsRepository(_KioscoDbcontext);

        public IVacantesRepository VacantesRepository => _VacantesRepository?? new VacantesRepository(_KioscoDbcontext);

        public IEncuestasInternasRepository EncuestasInternasRepository => _EncuestasInternasRepository ?? new EncuestasInternasRepository(_KioscoDbcontext);
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
