using KioscoWebView.Data;
using KioscoWebView.Data.DTO;
using KioscoWebView.Services;

namespace KioscoWebView.Services
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
            return await _httpService.Post<WebResponse<string>>("api/Login", GlovalSearch);
        }
    }
}
