using Kiosco.Core.Entities;
using Kiosco.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kiosco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacantesRequisitosController : ControllerBase
    {
        private readonly KioscoDbContext _kioscoDbContext;
        public VacantesRequisitosController(KioscoDbContext kioscoDbContext)
        {
            _kioscoDbContext = kioscoDbContext;
        }

        [HttpGet]
        public IActionResult GetVacantesRequisitos() => Ok(_kioscoDbContext.VacantesRequisitos.ToList());

        [HttpPost]
        public async Task<IActionResult> AddVacantesRequisitos(List<VacantesRequisitos> vacantes)
        {
            try
            {
                await _kioscoDbContext.VacantesRequisitos.AddRangeAsync(vacantes);
                //await _kioscoDbContext.VacantesRequisitos.AddRangeAsync(vacantes.VacanteRequisitos);
                await _kioscoDbContext.SaveChangesAsync();

                var result = new WebResponse<string>()
                {
                    body = "Success",
                    isSuccess = true,
                    message = "Success",
                    statusCode = "200",
                };

                return Ok(result);

            }
            catch (Exception ex)
            {
                var result = new WebResponse<string>()
                {
                    body = "Error Intentando crear una vacante",
                    isSuccess = false,
                    message = ex.Message,
                };

                return BadRequest(result);
            }
        }

    }
}
