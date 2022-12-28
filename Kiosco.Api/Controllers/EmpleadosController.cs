using Kiosco.Core.Entities;
using Kiosco.Core.Entities.DTO;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kiosco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly KioscoContextHCM _kioscoContextHCM;
        private readonly IUnitOfWork _unitOfWork;
        public EmpleadosController(KioscoContextHCM kioscoContextHCM, IUnitOfWork unitOfWork)
        {
            _kioscoContextHCM = kioscoContextHCM;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> GetVEmplByCode(GlobalSearchDTO Modulo)
        {
            vEmpleados response =await _unitOfWork.vEmpleadosRepository
                .GetById(v => v.EMP_PERSON_NUMBER.Contains(Modulo.Module));

            string[] resultOfSplit = response.SUP_NAME.Split(@",");

            vEmpleados sup_Email = await _unitOfWork.vEmpleadosRepository
                .GetById(v => v.Empleado.Contains(resultOfSplit[0].Trim()) && v.Empleado.Contains(resultOfSplit[1].Trim()));

            response.Sub_Email = sup_Email.EMAIL_ADDRESS;

            var result = new WebResponse<vEmpleados>()
            {
                body = response,
                isSuccess = true,
                message = "Success",
                statusCode = "200",
            };

            return Ok(result);
        }


    }
}
