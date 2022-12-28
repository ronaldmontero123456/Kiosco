using Kiosco.Core.Entities;
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
    public class EncuestasInternasRepository: BaseRepository<DbContext, EncuestasInternas> , IEncuestasInternasRepository
    {
        public EncuestasInternasRepository(KioscoDbContext dbContext) : base(dbContext){}
    }
}
