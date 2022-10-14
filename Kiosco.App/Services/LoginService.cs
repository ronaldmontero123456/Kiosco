using DPWCMSApp.Services;
using Kiosco.App.Data;
using Kiosco.App.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Kiosco.App.Services
{
    public interface ILoginService
    {
        Task<WebResponse<string>> LoginAsync(GlovalSearch GlovalSearch);
    }
    public class LoginService : ILoginService
    {
        private IHttpService _httpService;
        public LoginService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<WebResponse<string>> LoginAsync(GlovalSearch GlovalSearch)
        {
            var result = await _httpService.Post<WebResponse<string>>("api/Login", GlovalSearch);
            return await _httpService.Post<WebResponse<string>>("api/Login", GlovalSearch);
        }
    }
}
