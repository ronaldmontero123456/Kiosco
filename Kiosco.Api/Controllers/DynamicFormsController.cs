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
    public class DynamicFormsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly KioscoDbContext _context;
        public DynamicFormsController(IUnitOfWork unitOfWork, KioscoDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet]   
        public IActionResult GetDynamicForms()
        {
            var response =  _unitOfWork.DynamicFormsRepository.GetAll()
                                       .GroupBy(r => r.Modulo).Select(r => r.FirstOrDefault());

            var result = new WebResponse<IEnumerable<DynamicForms>>()
            {
                body = response,
                isSuccess = true,
                message = "Success",
                statusCode = "200",
            };

            return Ok(result);
        }
        [HttpPost]
        [Route("GetDynamicFormsByName")]
        public IActionResult GetDynamicFormsByName(GlobalSearchDTO Modulo)
        {
            var response =  _unitOfWork.DynamicFormsRepository.Get(u => u.Modulo == Modulo.Module);

            var result = new WebResponse<IEnumerable<DynamicForms>>()
            {
                body = response,
                isSuccess = true,
                message = "Success",
                statusCode = "200",
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDynamicForms(List<DynamicForms> dynamicForms)
        {
            try
            {
                await _unitOfWork.DynamicFormsRepository.AddRange(dynamicForms);
                await _context.SaveChangesAsync();

                var result = new WebResponse<List<DynamicForms>>()
                {
                    body = dynamicForms,
                    isSuccess = true,
                    message = "Success",
                    statusCode = "200",
                };

                return Ok(result);
            }
            catch (Exception)
            {
                var result = new WebResponse<List<DynamicForms>>()
                {
                    body = dynamicForms,
                    isSuccess = false,
                    message = "Bad",
                };

                return BadRequest(result);
            }           
        }


    }
}
