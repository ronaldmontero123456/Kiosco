using Kiosco.App.Data;
using Kiosco.Services;

namespace Kiosco.App.Services
{
    public interface IDynamicFormsService
    {
        Task Add(List<DynamicForms> dynamicForms);
        Task<WebResponse<List<DynamicForms>>> Get();
        Task<WebResponse<List<DynamicForms>>> GetByModule(GlobalSearchDTO Modulo);
    }
    public class DynamicFormsService : IDynamicFormsService
    {
        private IHttpService _httpService;
        public DynamicFormsService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task Add(List<DynamicForms> dynamicForms)
        {
            await _httpService.Post<WebResponse<List<DynamicForms>>>("api/DynamicForms", dynamicForms);
        }

        public async Task<WebResponse<List<DynamicForms>>> Get()
        {
            return await _httpService.Get<WebResponse<List<DynamicForms>>>("api/DynamicForms");
        }

        public async Task<WebResponse<List<DynamicForms>>> GetByModule(GlobalSearchDTO Modulo)
        {
            return await _httpService.Post<WebResponse<List<DynamicForms>>>("api/DynamicForms/GetDynamicFormsByName", Modulo);
        }
    }
}
