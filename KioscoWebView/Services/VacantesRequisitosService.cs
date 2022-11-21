using KioscoWebView.Data;
using KioscoWebView.Services;

namespace KioscoWebView.Services
{
        public interface IVacantesRequisitosService
        {
            Task<WebResponse<IEnumerable<VacantesRequisitos>>> GetVacantesAsync();
            Task AddVacantesRequisitosAsync(List<VacantesRequisitos> vacante);
        }

        public class VacantesRequisitosService : IVacantesRequisitosService
        {

            IHttpService _httpService;

            public VacantesRequisitosService(IHttpService httpService)
            {
                _httpService = httpService;
            }

            public async Task<WebResponse<IEnumerable<VacantesRequisitos>>> GetVacantesAsync()
            {
                return await _httpService.Get<WebResponse<IEnumerable<VacantesRequisitos>>>("api/Vacantes");
            }
            public async Task AddVacantesRequisitosAsync(List<VacantesRequisitos> vacante)
            {
                await _httpService.Post<WebResponse<string>>("api/VacantesRequisitos", vacante);
            }
        }
}
