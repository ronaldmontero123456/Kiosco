using Kiosco.Core.Entities;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;

namespace Kiosco.Infrastructure.Repositories
{
    public class DynamicFormsRepository : BaseRepository<DynamicForms>, IDynamicFormsRepository
    {
        public DynamicFormsRepository(KioscoContext context) : base(context) { }
    }
}
