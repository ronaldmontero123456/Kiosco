using Kiosco.App.Data;
using Kiosco.Services;

namespace Kiosco.App.Services
{
    public interface IEncuestasInternasService
    {
        Task<WebResponse<int>> Add(EncuestasInternas dynamicForms);
        Task AddDetalle(List<EncuestasInternasDetalle> dynamicForms);
        Task<WebResponse<List<EncuestasInternas>>> Get();
    }


    public class EncuestasInternasService : IEncuestasInternasService
    {
        private IHttpService _httpService;

        public EncuestasInternasService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<WebResponse<int>> Add(EncuestasInternas Encuestas)
        {
            return await _httpService.Post<WebResponse<int>>("api/Encuestas", Encuestas);
        }

        public async Task AddDetalle(List<EncuestasInternasDetalle> Encuestas)
        {
             await _httpService.Post<WebResponse<int>>("api/Encuestas/AddDetalle", Encuestas);
        }

        public async Task<WebResponse<List<EncuestasInternas>>> Get()
        {
            return await _httpService.Get<WebResponse<List<EncuestasInternas>>>("api/Encuestas");
        }
    }
}
