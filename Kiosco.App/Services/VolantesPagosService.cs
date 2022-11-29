
using DPWCMSApp.Services;
using Kiosco.App.Data;
using Kiosco.Services;

namespace Kiosco.App.Services
{

    public interface IVolantesPagosService
    {
        Task<VolantesPagos> GetVolantesPagos();
    }


    public class VolantesPagosService: IVolantesPagosService
    {
        IHttpService _httpService;
        ILocalStorageService _localStorageService;
        public VolantesPagosService(IHttpService httpService, ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _localStorageService = localStorageService;
        }

        public async Task<VolantesPagos> GetVolantesPagos()
        {
            string CarnetCode = await _localStorageService.GetItem<string>("CarnetCode");
            return await _httpService.Get<VolantesPagos>
                    ($@"https://treboldpw.com/ords/nominadpw/volantes/consultapago?VUSUARIO=DPWDR&VCLAVE=DpwDR.2022%40&VNOMINA=1&VANIO=2022&VNOPERIODO=15&VEMPLEADO={CarnetCode}");
        }
    }
}


