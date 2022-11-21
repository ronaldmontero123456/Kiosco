using Kiosco.Core.Entities;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kiosco.Infrastructure.Repositories
{
    public class LoginRepository : BaseRepository<DbContext, Empleados>, ILoginRepository
    {
        public LoginRepository(KioscoContext context) : base(context) { }
}
}
