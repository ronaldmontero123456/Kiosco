using DPWCMSApp.Services;
using Kiosco.App.Data;
using System.Text;
using System.Text.Json;

namespace Kiosco.App.Services
{
    public interface ISendMailService
    {
        Task SendEmail(string subject, string toMail, string file, string BodyMessage);
    }

    public class SendMailService : ISendMailService
    {
        ILocalStorageService _LocalStorageService;
        IEmpleadosServices _EmpleadosServices;
        IConfiguration _configuration;
        public SendMailService(ILocalStorageService LocalStorageService, IEmpleadosServices EmpleadosServices, IConfiguration configuration)
        {
            _LocalStorageService = LocalStorageService;
            _EmpleadosServices = EmpleadosServices;
            _configuration = configuration;
        }

        public async Task SendEmail(string subject, string toMail, string file, string BodyMessage)
        {
            try
            {
                string carnetCode = await _LocalStorageService.GetItem<string>("CarnetCode");

                GlobalSearchDTO searchDTO = new GlobalSearchDTO();
                searchDTO.Module = carnetCode;

                var result = await _EmpleadosServices.GetByCode(searchDTO);

                string body = $@"
                                Favor hacer Click en el boton para continuar con el proceso de la aprobación  
                                para el proceso reclutamiento interno de ""{result.body.Empleado}""
                                <html>
                                <head>
                                <style>
                                a {{
                                  color: #1E1450;
                                }}
                                </style>
                                </head>
                                <body>

                                <p><b><a href=""https://localhost:7267/SignatureSuperPage/{file}"" target=""_blank"">This is a link</a></b></p>

                                </body>
                                </html>


                                <!DOCTYPE html>
                                    <div>
                                            <table class=""table"">
                                                <thead>
                                                    <tr>
                                                        <th scope=""col"">ID</th>
                                                        <th scope=""col"">Nombre del empleado</th>
                                                        <th scope=""col"">Posición Actual</th>
                                                        <th scope=""col"">Tiempo en la posición actual</th>
                                                        <th scope=""col"">Aplicando para el puesto</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                        <tr>
                                                            <td>{carnetCode}</td>
                                                            <th>{result.body.Empleado}</th>
                                                            <td>{toMail}</td>
                                                            <td>{result.body.START_DATE}</td>
                                                            <td>{result.body.POSITION_NAME}</td>
                                                        </tr>
                                            </tbody>
                                        </table>
                                    </div>";

                MailModel mail = new()
                {
                    From = _configuration["SendCorreo"], //"CaucedoAvisos@DPWorld.com.do",
                    BodyMessage = body,
                    Subject = subject,
                    ToMail = result.body.Sub_Email,
                    CarbonCopy = "",
                    Attachtments = new string[] { },
                    UseHtml = true,
                    TemplateName = "BasicTemplate1",
                };
                string json = JsonSerializer.Serialize(mail);
                HttpClient client = new() { BaseAddress = new Uri("http://192.168.6.223/CaucedoWebApi/Utils/") };
                HttpResponseMessage request = await client.PostAsync("Notification/api/Mail/", new StringContent(json, Encoding.UTF8, "application/json"));

                if (!request.IsSuccessStatusCode)
                    throw new Exception(await request.RequestMessage.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
