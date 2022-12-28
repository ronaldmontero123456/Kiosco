using Kiosco.Core.Entities;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Kiosco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestasController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly KioscoDbContext _kioscoDbContext;
        public EncuestasController(IUnitOfWork UnitOfWork, KioscoDbContext kioscoDbContext)
        {
            _UnitOfWork = UnitOfWork;
            _kioscoDbContext = kioscoDbContext;
        }


        [HttpGet]
        public IActionResult GetEncuestasInternas()
        {
            var result = new WebResponse<IEnumerable<EncuestasInternas>>()
            {
                body = _UnitOfWork.EncuestasInternasRepository.GetAll(),
                isSuccess = true,
                message = "Success",
                statusCode = "200",
            };

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddEncuestasInternas(EncuestasInternas EncuestaInterna)
        {
            try
            {
                await _UnitOfWork.EncuestasInternasRepository.Add(EncuestaInterna);

                await _kioscoDbContext.SaveChangesAsync();

                var result = new WebResponse<int>()
                {
                    body = _UnitOfWork.EncuestasInternasRepository.GetAll().Max(v => v.EncId),
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
        

        [HttpPost]
        [Route("AddDetalle")]
        public async Task<IActionResult> AddDetalle(List<EncuestasInternasDetalle> EncuestaInterna)
        {
            try
            {
                _kioscoDbContext.EncuestasInternasDetalle.AddRange(EncuestaInterna);
                await _kioscoDbContext.SaveChangesAsync();

                var result = new WebResponse<int>()
                {
                    body = 1,
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
