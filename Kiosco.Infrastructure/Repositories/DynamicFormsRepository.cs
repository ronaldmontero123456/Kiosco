using Kiosco.Core.Entities;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kiosco.Infrastructure.Repositories
{
    public class DynamicFormsRepository : BaseRepository<DbContext, DynamicForms>, IDynamicFormsRepository
    {
        public DynamicFormsRepository(KioscoContext context) : base(context) { }
    }
}
