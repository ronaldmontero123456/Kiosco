using Kiosco.Core.Entities.DTO;
using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Kiosco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly KioscoContext _context;
        private readonly IConfiguration _configuration;
        public LoginController(IUnitOfWork unitOfWork, KioscoContext context, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody]GlovalSearch GlovalSearch)
        {
            var response = SpReader($"spGetEmpByCarnetCode '{GlovalSearch.CarnetCode ?? ""}'");

            if (response != null)
            {
                var result = new WebResponse<string>()
                {
                    body = response.Rows[0].ItemArray[2].ToString(),
                    isSuccess = true,
                    message = "Success",
                    statusCode = "200",
                };
                return Ok(result);
            }

           return Ok(new WebResponse<string>()
           {
               body = "Carnet Code Invalid",
               isSuccess = true,
               message = "Success",
               statusCode = "200",
           });
        }

        public DataTable SpReader(string value)
        {            
            SqlDataAdapter adapt = new SqlDataAdapter(value, (SqlConnection)_context.Database.GetDbConnection());
            DataTable result = new DataTable();
            adapt.Fill(result);

            return result;
        }
    }
}
