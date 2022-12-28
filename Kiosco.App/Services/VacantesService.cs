using Kiosco.App.Data;
using Kiosco.Services;

namespace Kiosco.App.Services
{
    public interface IVacantesService
    {
        Task<WebResponse<IEnumerable<Vacantes>>> GetVacantesAsync();
        Task<WebResponse<IEnumerable<VacantesAplicar>>> GetVacantesAplicarAsync();
        Task<WebResponse<int>> AddVacantesAsync<T>(T vacante);
        Task<WebResponse<int>> AddVacantesAsync(VacantesAplicar vacante);
    }
    

    public class VacantesService : IVacantesService
    {

        IHttpService _httpService;

        public VacantesService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<WebResponse<IEnumerable<Vacantes>>> GetVacantesAsync()
        {
            return await _httpService.Get<WebResponse<IEnumerable<Vacantes>>>("api/Vacantes");
        }
        public async Task<WebResponse<int>> AddVacantesAsync<T>(T vacante)
        {
            return await _httpService.Post<WebResponse<int>>("api/Vacantes", vacante);
        }
        public async Task<WebResponse<int>> AddVacantesAsync(VacantesAplicar vacante)
        {
            return await _httpService.Post<WebResponse<int>>("api/Vacantes/AddVacanteAplicar", vacante);
        }

        public async Task<WebResponse<IEnumerable<VacantesAplicar>>> GetVacantesAplicarAsync()
        {
            return await _httpService.Get<WebResponse<IEnumerable<VacantesAplicar>>>("api/Vacantes/GetVacanteAplicar");
        }
    }
}
