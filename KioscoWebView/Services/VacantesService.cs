using KioscoWebView.Data;
using KioscoWebView.Services;

namespace KioscoWebView.Services
{
    public interface IVacantesService
    {
        Task<WebResponse<IEnumerable<Vacantes>>> GetVacantesAsync();
        Task<WebResponse<int>> AddVacantesAsync(Vacantes vacante);
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
        public async Task<WebResponse<int>> AddVacantesAsync(Vacantes vacante)
        {
            return await _httpService.Post<WebResponse<int>>("api/Vacantes", vacante);
        }
    }
}
