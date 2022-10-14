using DPWCMSApp.Model;
using Kiosco.App.Data;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace DPWCMSApp.Services
{

    public interface IHttpService
    {
        Task<T> Get<T>(string uri);
        Task<T> Post<T>(string uri, object value);
        Task<T> SendPost<T>(string uri, object value);
        Task<T> Put<T>(string uri, object value);
        Task<T> GetFile<T>(string uri);
        Task<byte[]> PostFile<T>(string uri, object value);
    }

    public class HttpService : IHttpService
    {
        private HttpClient _httpClient;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private IConfiguration _configuration;

        public HttpService(
            HttpClient httpClient,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService,
            IConfiguration configuration
        )
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
            _configuration = configuration;
        }

        public async Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await sendRequest<T>(request);
        }

        public async Task<T> GetFile<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            //throw new NotImplementedException();
            //request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            //request.Content = new MediaTypeHeaderValue("application/octet-stream");
            return await sendRequest<T>(request);
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            string post = JsonSerializer.Serialize(value);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return await sendRequest<T>(request);
        }

        public async Task<byte[]> PostFile<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return await sendRequest2<T>(request);
        }

        public async Task<T> Put<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return await sendRequest<T>(request);
        }

        public async Task<T> SendPost<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            //request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return await LoginRequest<T>(request);
        }

        // helper methods

        private async Task<T> sendRequest<T>(HttpRequestMessage request)
        {

            // add jwt auth header if user is logged in and request is to the api url
            var user = await _localStorageService.GetItem<AuthenticateResponse>("user");
            var isApiUrl = !request.RequestUri.IsAbsoluteUri;
            if (user != null && isApiUrl)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);

            using var response = await _httpClient.SendAsync(request);

            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("/pages/authentication/logout");
                return default;
            }

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }

        private async Task<byte[]> sendRequest2<T>(HttpRequestMessage request)
        {
            // add jwt auth header if user is logged in and request is to the api url
            var user = await _localStorageService.GetItem<AuthenticateResponse>("user");
            var isApiUrl = !request.RequestUri.IsAbsoluteUri;
            if (user != null && isApiUrl)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
            
            using var response = await _httpClient.SendAsync(request);

            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("/pages/authentication/logout");
                return default;
            }

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            return await response.Content.ReadAsByteArrayAsync();
        }

        private async Task<T> LoginRequest<T>(HttpRequestMessage request)
        {
            // add jwt auth header if user is logged in and request is to the api url
            //var user = await _localStorageService.GetItem<AuthenticateResponse>("user");

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://rosteringintegrationapi-uat.cargoes.com");

                AuthenticateRequest authenticate = new AuthenticateRequest()
                {
                    Username = "DPWC",
                    Password = "Poem$2021"
                };

                var requestToLogin = new HttpRequestMessage(HttpMethod.Post, "/Token");
                requestToLogin.Content = new StringContent(JsonSerializer.Serialize(authenticate), Encoding.UTF8, "application/json");
                var token = await client.SendAsync(requestToLogin);

                //var isApiUrl = !request.RequestUri.IsAbsoluteUri;
                var tokenresponse = await token.Content.ReadFromJsonAsync<AuthenticateResponse>();

                if (tokenresponse != null && token.StatusCode != HttpStatusCode.Unauthorized)
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenresponse.Token);

                using var response = await client.SendAsync(request);

                // auto logout on 401 response
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _navigationManager.NavigateTo("/pages/authentication/logout");
                    return default;
                }

                // throw exception on error response
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                    throw new Exception(error["message"]);
                }

                var responses = await response.Content.ReadAsStringAsync();

                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
               throw;
            }

        }

    }
}
