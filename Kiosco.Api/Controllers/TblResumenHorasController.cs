using Kiosco.Core.Entities;
using Kiosco.Core.Entities.DTO;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Kiosco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblResumenHorasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly KioscoContext _context;

        public TblResumenHorasController(IUnitOfWork unitOfWork, KioscoContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        [HttpGet(Name = nameof(TblResumenHoras))]
        public IActionResult GetTblResumenHoras() => Ok(_unitOfWork.TblResumenHorasRepository.GetAll());

        [HttpPost]
        public async Task<IActionResult> GetTblResumenHoras(GlobalSearchDTO tblResumenHoras)
        {
            Expression<Func<TblResumenHoras, bool>> expression = GetExpression(tblResumenHoras);

            IEnumerable<TblResumenHoras> resumenHoras = _unitOfWork.TblResumenHorasRepository.Get(expression);

            return Ok(resumenHoras);
        }

        private Expression<Func<TblResumenHoras, bool>> GetExpression(GlobalSearchDTO tblResumenHoras)
        {
            return e => e.HFNOM >= tblResumenHoras.DateFrom;
        }

    }
}
