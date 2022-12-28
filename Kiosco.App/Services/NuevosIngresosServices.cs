using DPWorldDR.Shared.Contracts;
using DPWorldDR.Shared.Contracts.Enum;
using DPWorldDR.Shared.Entities;
using DPWorldDR.Shared.Utilities;
using Kiosco.App.Data;
using System.Net;
using System.Text;

namespace Kiosco.App.Services
{
    public interface INuevosIngresosServices
    {
        Task<IEnumerable<NuevosIngresos>> GetNuevosIngresosAsync();
    }


    public class NuevosIngresosServices : INuevosIngresosServices
    {
        private readonly ICustomLogger _customLogger;
        private readonly IOracleServices _oracleServices;
        public NuevosIngresosServices(ICustomLogger customLogger, IOracleServices oracleServices)
        {
            _customLogger = customLogger;
            _oracleServices = oracleServices;
        }

        public async Task<IEnumerable<NuevosIngresos>> GetNuevosIngresosAsync()
        {
            var result = GetData(
             new OraReportParams()
             {
                 rptRoute = $"/Custom/Human Capital Management/SysReports/DP New Hire Report.xdo",
                 format = FILE_FORMAT.csv,
                 reportServiceEndPoint = "https://egby.fa.us6.oraclecloud.com/xmlpserver/services/v2/ReportService",
                 userName = "IImplementator",
                 password = "Fusion2017@",
             });

            return result;
        }

        private List<NuevosIngresos> GetData(IOraReportParams parameters)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(parameters.reportServiceEndPoint);
            request.Headers.Add("SOAPAction:");
            request.ContentType = "text/xml";
            request.Method = "POST";
            request.KeepAlive = true;
            byte[] byteArray = Encoding.UTF8.GetBytes(parameters.AsXML);
            request.ContentLength = byteArray.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(byteArray, 0, byteArray.Length);
            requestStream.Close();
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                _customLogger.Fatal(ex.Message);
                response = (HttpWebResponse)ex.Response;
            }
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            //List<HcmEmployeeDto> result1 = (List<HcmEmployeeDto>)new XmlSerializer(typeof(HcmEmployeeDto)).Deserialize(reader);
            var text = reader.ReadToEnd();
            text = text.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?><soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><soapenv:Body><runReportResponse xmlns=\"http://xmlns.oracle.com/oxp/service/v2\"><runReportReturn><metaDataList xsi:nil=\"true\"/><reportBytes>", "");
            text = text.Replace($"</reportBytes><reportContentType>text/plain;charset=UTF-8</reportContentType><reportFileID xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:nil=\"true\"/><reportLocale xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:nil=\"true\"/></runReportReturn></runReportResponse></soapenv:Body></soapenv:Envelope>", "");
            text = text.Replace($"<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><soapenv:Body><runReportResponse xmlns=\"http://xmlns.oracle.com/oxp/service/v2\"><runReportReturn><metaDataList xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:nil=\"true\"/><reportBytes>", "");

            //var json = JObject.Parse(text);

            //XmlSerializer serializer = new XmlSerializer(typeof(HcmEmployeeDto));
            //using (TextReader reader1 = new StringReader(text))
            //{
            //    List<HcmEmployeeDto> result1 = (List<HcmEmployeeDto>)serializer.Deserialize(reader1);
            //}

            var result = text.ToBase64Decode();
            result = result.Replace("T00:00:00.000+00:00", "");


            reader.Close();
            requestStream.Close();
            responseStream.Close();
            response.Close();


            List<NuevosIngresos> ValuesToReturn = new List<NuevosIngresos>();
            var values = result.Split(new string[] { "\r\n", "\n", "\n" }, StringSplitOptions.None);
            //var values = result.Split(";", StringSplitOptions.None);

            foreach (var value in values.Skip(1))
            {
                if (string.IsNullOrEmpty(value))
                {
                    continue;
                }

                var res = value.Split(';');

                //var HcmEmployeeDto = Activator.CreateInstance(typeof(T), false);

                NuevosIngresos nuevoIngreso = new NuevosIngresos
                {
                    HIRE_DATE = res[0],
                    FIRST_NAME= res[1],
                    LAST_NAME= res[2],
                    DEPARTMENT= res[3],
                    ACTION_NAME= res[4],
                    JOB_NAME= res[5],
                    LOCATION_NAME= res[6],
                    POSITION_NAME= res[7],
                    MANAGER_NAME= res[8],
                    PERSON_NAME= res[9],
                    MIDDLE_NAME = res[10],
                };

                //for (int i = 0; i < res.Length; i++)
                //{
                //    var rex = HcmEmployeeDto?.GetType().GetProperties();
                //    var re = HcmEmployeeDto?.GetType().GetProperties().FirstOrDefault(p => p.Name.Contains(res[i].Trim()));
                //    if (re != null)
                //        re.SetValue(HcmEmployeeDto, value.Split(';')[i]);
                //    else
                //    {
                //        re = HcmEmployeeDto?.GetType().GetProperties().FirstOrDefault(p => p.Name.Contains("﻿HIRE_DATE"));
                //        re?.SetValue(HcmEmployeeDto, value.Split(';')[i]);
                //    }
                //}

                ValuesToReturn.Add(nuevoIngreso);
            }

            //XmlSerializer serializer = new XmlSerializer(typeof(Promociones));
            //using (TextReader reader1 = new StringReader(text))
            //{
            //    List<Promociones> result1 = (List<Promociones>)serializer.Deserialize(reader1);
            //}

            return ValuesToReturn;
        }
    }

}

