
using KioscoWebView.Data;
using KioscoWebView.Services;

namespace KioscoWebView.Services
{

    public interface IVolantesPagosService
    {
        Task<VolantesPagos> GetVolantesPagos();
    }


    public class VolantesPagosService: IVolantesPagosService
    {
        IHttpService _httpService;
        public VolantesPagosService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<VolantesPagos> GetVolantesPagos()
        {
            return await _httpService.Get<VolantesPagos>
                    ($@"https://treboldpw.com/ords/nominadpw/volantes/consultapago?VUSUARIO=DPWDR&VCLAVE=DpwDR.2022%40&VNOMINA=1&VANIO=2022&VNOPERIODO=15&VEMPLEADO=2044");
        }
    }
}


