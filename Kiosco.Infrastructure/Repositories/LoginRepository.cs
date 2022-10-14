using Kiosco.Core.Entities;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;

namespace Kiosco.Infrastructure.Repositories
{
    public class LoginRepository : BaseRepository<Empleados>, ILoginRepository
    {
        public LoginRepository(KioscoContext context) : base(context) { }
}
}
