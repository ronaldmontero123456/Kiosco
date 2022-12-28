using Kiosco.App.Data;
using Kiosco.Services;

namespace Kiosco.App.Services
{
    public interface IEmpleadosServices
    {
        Task<WebResponse<vEmpleados>> GetByCode(GlobalSearchDTO Modulo);
    }

    public class EmpleadosServices : IEmpleadosServices
    {

        private IHttpService _httpService;
        public EmpleadosServices(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<WebResponse<vEmpleados>> GetByCode(GlobalSearchDTO Modulo)
        {
            return await _httpService.Post<WebResponse<vEmpleados>>("api/Empleados", Modulo);
        }
    }
}
