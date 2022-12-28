using DPWorldDR.Shared.Contracts;
using DPWorldDR.Shared.Contracts.Enum;
using DPWorldDR.Shared.Entities;
using DPWorldDR.Shared.Utilities;
using Kiosco.App.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace Kiosco.App.Services
{

    public interface IPromocionesService
    {
        Task<IEnumerable<Promociones>> GetPromocionesAsync();   
    }



    public class PromocionesService : IPromocionesService
    {
        private readonly ICustomLogger _customLogger;
        private readonly IOracleServices _oracleServices;

        public PromocionesService(ICustomLogger customLogger, IOracleServices oracleServices)
        {
            _customLogger = customLogger;
            _oracleServices = oracleServices;
        }

        public ICustomLogger CustomLogger { get; }

        public async Task<IEnumerable<Promociones>> GetPromocionesAsync()
        {
            try
            {

                //var result1 = getdata(
                //    new orareportparams()
                //    {

                //        rptroute = "/custom/human capital management/sysreports/employees/employee cargoes rostering.xdo",
                //        format = file_format.csv,
                //        reportserviceendpoint = "https://egby.fa.us6.oraclecloud.com/xmlpserver/services/v2/reportservice",
                //        username = "iimplementator",
                //        password = "fusion2017@",
                //    });

                //New Hire
                //Promotions

                var result = GetData<Promociones>(
                    new OraReportParams() {
                        rptRoute = $"/Custom/Human Capital Management/SysReports/DP Promotions Report.xdo",
                        format = FILE_FORMAT.csv,
                        reportServiceEndPoint = "https://egby.fa.us6.oraclecloud.com/xmlpserver/services/v2/ReportService",
                        userName = "IImplementator",
                        password = "Fusion2017@",
                    });


                return result;
            }
            catch(Exception ex)
            {
                _customLogger.Fatal(ex.Message);
                throw;
            }
        }
        private List<T> GetData<T>(IOraReportParams parameters)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(parameters.reportServiceEndPoint);
            request.Headers.Add("SOAPAction:");
            request.ContentType ="text/xml";
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


            List<T> ValuesToReturn = new List<T>(); 
            var values = result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            foreach(var value in values.Skip(1))
            {
                if(string.IsNullOrEmpty(value))
                {
                    continue;
                }

                var res = values[0].Split(',');

                var HcmEmployeeDto = Activator.CreateInstance(typeof(T),false);

                for (int i = 0; i < res.Length;  i++)
                {
                    var rex = HcmEmployeeDto?.GetType().GetProperties();
                    var re = HcmEmployeeDto?.GetType().GetProperties().FirstOrDefault(p => p.Name.Contains(res[i].Trim()));
                    if(re != null)
                    re.SetValue(HcmEmployeeDto, value.Split(',')[i]);
                    else
                    {
                        re = HcmEmployeeDto?.GetType().GetProperties().FirstOrDefault(p => p.Name.Contains("FIRST_NAME"));
                        re?.SetValue(HcmEmployeeDto, value.Split(',')[i]);
                    }
                }

                ValuesToReturn.Add((T)HcmEmployeeDto);
            }

            //XmlSerializer serializer = new XmlSerializer(typeof(Promociones));
            //using (TextReader reader1 = new StringReader(text))
            //{
            //    List<Promociones> result1 = (List<Promociones>)serializer.Deserialize(reader1);
            //}

            return ValuesToReturn;
        }
    }

    public class HcmEmployeeDto
    {
        [JsonProperty("EMP_PERSON_NUMBER")]
        public string PersonNumber { get; set; }



        [JsonProperty("PERSON_NUMBER")]
        [Display(Name = "PERSON_NUMBER")]
        public string PersonNumber2 { get; set; }



        [JsonProperty("EFFECTIVE_START_DATE")]
        [Display(Name = "EFFECTIVE_START_DATE")]
        public DateTime EfectiveStartDate { get; set; }



        [JsonProperty("EFFECTIVE_END_DATE")]
        [Display(Name = "EFFECTIVE_END_DATE")]
        public DateTime EfectiveEndDate { get; set; }



        [JsonProperty("EMPLOYEE_CATEGORY")]
        [Display(Name = "EMPLOYEE_CATEGORY")]
        public string EMPLOYEE_CATEGORY { get; set; }



        [JsonProperty("JOB_FUNCTION_CODE")]
        public string JobFunctionCode { get; set; }



        [JsonProperty("JOB_CODE")]
        public string JobCode { get; set; }



        [JsonProperty("EMP_LAST_NAME")]
        public string LastName { get; set; }



        [JsonProperty("EMP_MATERNAL_LAST")]
        public string MaternalLastName { get; set; }



        [JsonProperty("EMP_NAME")]
        public string Name { get; set; }



        [JsonProperty("EMP_MIDDLE_NAME")]
        public string MiddleName { get; set; }



        [JsonProperty("SUP_NAME")]
        public string SupervisorName { get; set; }



        [JsonProperty("SUP_PERSON_NUMBER")]
        public string SupervisorPersonNumber { get; set; }



        [JsonProperty("STATUS")]
        public string Status { get; set; }



        [JsonProperty("START_DATE")]
        public DateTime startDate { get; set; }



        [JsonProperty("NATIONAL_IDENTIFIER_NUMBER")]
        public string NationalIdentifierNumber { get; set; }



        [JsonProperty("ADDRESS_LINE_1")]
        public string AddressLine1 { get; set; }



        [JsonProperty("ADDRESS_LINE_2")]
        public string AddressLine2 { get; set; }



        [JsonProperty("ADDRESS_LINE_3")]
        public string AddressLine3 { get; set; }



        [JsonProperty("TOWN_OR_CITY")]
        public string TownCity { get; set; }



        [JsonProperty("PHONE_TYPE")]
        public string PhoneType { get; set; }



        [JsonProperty("PHONE_NUMBER")]
        public string PhoneNumber { get; set; }



        [JsonProperty("AREA_CODE")]
        public string AreaCode { get; set; }



        [JsonProperty("COUNTRY_CODE_NUMBER")]
        public string CountryCode { get; set; }



        [JsonProperty("EMAIL_ADDRESS")]
        public string EmailAddress { get; set; }



        [JsonProperty("DATE_OF_BIRTH")]
        public DateTime DateofBirth { get; set; }



        [JsonProperty("SEX")]
        public string Sex { get; set; }



        [JsonProperty("MARITAL_STATUS")]
        public string MaritalStatus { get; set; }



        [JsonProperty("EMPLOYMENT_CATEGORY")]
        public string EmploymentCategory { get; set; }



        [JsonProperty("HOURLY_SALARIED_CODE")]
        public string HourlySalariedCode { get; set; }



        [JsonProperty("NORMAL_HOURS")]
        public string NormalHours { get; set; }



        [JsonProperty("POSITION_CODE")]
        public string PositionCode { get; set; }



        [JsonProperty("POSITION_NAME")]
        public string PositionName { get; set; }



        [JsonProperty("DEPARTMENT")]
        public string Department { get; set; }



        [JsonProperty("LOCATION_NAME")]
        public string LocationName { get; set; }



        [JsonProperty("GRADE_CODE")]
        public string GradeCode { get; set; }



        [JsonProperty("GRADE_NAME")]
        public string GradeName { get; set; }



        [JsonProperty("JOB_NAME")]
        public string JobName { get; set; }



        [JsonProperty("REGULAR_TEMPORARY")]
        public string RegularTemporary { get; set; }



        [JsonProperty("FULL_PART_TIME")]
        public string FullPartType { get; set; }



        [JsonProperty("EMPLOYEE_CATG_MEANING")]
        public string EmployeeCatgMeaning { get; set; }



        [JsonProperty("JOB_FAMILY_CODE")]
        public string JobFamilyCode { get; set; }



        [JsonProperty("JOB_FAMILY_NAME")]
        public string JobFamilyName { get; set; }



        [JsonProperty("SALARY_BASIS_NAME")]
        public string SalaryBasisName { get; set; }



        [JsonProperty("EMP_IDENTIFIER")]
        public string EmployeeIdentifier { get; set; }



        //Termination Properties
        [JsonProperty("TERMINATION_DATE")]
        public DateTime? ActualTerminationDate { get; set; }



        [JsonProperty("ACTION_NAME")]
        public string TerminationActionName { get; set; }



        [JsonProperty("ACTION_REASON")]
        public string TerminationActionReason { get; set; }

    }

}
