using Kiosco.Core.Entities;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kiosco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacantesController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly KioscoDbContext _kioscoDbContext;
        public VacantesController(IUnitOfWork UnitOfWork, KioscoDbContext kioscoDbContext)
        {
            _UnitOfWork = UnitOfWork;
            _kioscoDbContext = kioscoDbContext;
        }

        [HttpGet]
        public IActionResult GetVacantes()
        {
            var result = new WebResponse<IEnumerable<Vacantes>>()
            {
                body = _UnitOfWork.VacantesRepository.GetAll(),
                isSuccess = true,
                message = "Success",
                statusCode = "200",
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddVacante(Vacantes vacantes)
        {
            try
            {
                await _UnitOfWork.VacantesRepository.Add(vacantes);
                //await _kioscoDbContext.VacantesRequisitos.AddRangeAsync(vacantes.VacanteRequisitos);
                await _kioscoDbContext.SaveChangesAsync();

               var result = new WebResponse<int>()
               {
                   body = _UnitOfWork.VacantesRepository.GetAll().Max(v => v.VacanteId),
                   isSuccess = true,
                   message = "Success",
                   statusCode = "200", 
               };

                return Ok(result);

            }
            catch (Exception ex)
            {
                var result = new WebResponse<int>()
                {
                    body = -1,
                    isSuccess = false,
                    message = ex.Message,
                };

                return BadRequest(result);
            }           
        }

    }
}
