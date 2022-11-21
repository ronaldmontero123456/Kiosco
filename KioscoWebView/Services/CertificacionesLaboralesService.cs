using DPWCMSApp.Services;
using DPWorldDR.Shared.Contracts;
using DPWorldDR.Shared.Contracts.Enum;
using DPWorldDR.Shared.Entities;
using KioscoWebView.Data;
using KioscoWebView.Utils;

namespace KioscoWebView.Services
{
    public interface ICertificacionesLaboralesService
    {
        Task<CertificacionesLaborales> GetCertificacionesLaboralesAsync();
    }

    public class CertificacionesLaboralesService: ICertificacionesLaboralesService
    {
        private ILocalStorageService _localStorageService;
        private readonly ICustomLogger _customLogger;
        private readonly IOracleServices _oracleServices;

        public CertificacionesLaboralesService(ILocalStorageService localStorageService, ICustomLogger customLogger, IOracleServices oracleServices)
        {
            _localStorageService = localStorageService;
            _customLogger = customLogger;
            _oracleServices = oracleServices;   
        }

        public async Task<CertificacionesLaborales> GetCertificacionesLaboralesAsync()
        {
            var result = Functions.GetDataFromOracle<CertificacionesLaborales>(
            new OraReportParams()
            {
                rptRoute = "/Custom/Human Capital Management/SysReports/DP Kiosko Employees.xdo",
                format = FILE_FORMAT.csv,
                reportServiceEndPoint = "https://egby.fa.us6.oraclecloud.com/xmlpserver/services/v2/ReportService",
                userName = "IImplementator",
                password = "Fusion2017@",
                FieldsParams = new List<OraReportParam>()
                    {
                         new OraReportParam()
                         {
                           DataType = "String",
                           DefaultValue = "",
                           Label = "Codigo Del Empleado",
                           Name = "p_perNum",
                           Value = await _localStorageService.GetItem<string>("CarnetCode")
                         },
                         new OraReportParam()
                         {
                           DataType = "Date",
                           DateFormatString = "MM-dd-yyyy",
                           DefaultValue = DateTime.Now.ToString("MM-dd-yyyy"),
                           Label = "Fecha de Efectividad",
                           Name = "p_effdate",
                           Value = DateTime.Now.ToString("MM-dd-yyyy")
                         }
                    }
            });

            return result.FirstOrDefault() ?? new CertificacionesLaborales();
        }
    }
}
