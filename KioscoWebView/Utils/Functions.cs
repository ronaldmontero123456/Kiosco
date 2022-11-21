using DPWorldDR.Shared.Contracts;
using DPWorldDR.Shared.Utilities;
using System.Net;
using System.Text;

namespace KioscoWebView.Utils
{
    public static class Functions
    {
        public static List<T> GetDataFromOracle<T>(IOraReportParams parameters)
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
                response = (HttpWebResponse)ex.Response;
                throw ex;
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

            foreach (var value in values.Skip(1))
            {
                if (string.IsNullOrEmpty(value))
                {
                    continue;
                }

                var res = values[0].Split(',');

                var HcmEmployeeDto = Activator.CreateInstance(typeof(T), false);

                string[] valuetouse = value.Split(',');
                
                for (int i = 0; i < res.Length; i++)
                {
                    var rex = HcmEmployeeDto?.GetType().GetProperties();
                    var re = HcmEmployeeDto?.GetType().GetProperties().FirstOrDefault(p => p.Name.Contains(res[i].Trim()));

                    if (re != null)
                        re.SetValue(HcmEmployeeDto, valuetouse[i]);
                    //else
                    //{
                    //    re = HcmEmployeeDto?.GetType().GetProperties().FirstOrDefault(p => p.Name.Contains("FIRST_NAME"));
                    //    re?.SetValue(HcmEmployeeDto, value.Split(',')[i]);
                    //}
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
        public static string NumberToText(int number)
        {
            if (number == 0) return "Zero";


            if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";

            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (number < 0)
            {
                sb.Append("Menos ");
                number = -number;
            }


            string[] words0 = {"" ,"Uno ", "Dos ", "Tres ", "Cuatro ",
                              "Cinco " ,"Seis ", "Siete ", "Ocho ", "Nueve "};


            string[] words1 = {"Dies ", "Onces ", "Doce ", "Trece ", "Catorce ",
                                "Quince ","Diez y Seis ","Diez y Siete","Diez y Ocho ", "Diez y Nueve "};


            string[] words2 = {"Vente ", "Trenta ", "Cuarenta ", "Cincuenta ", "Sesenta ",
                               "Setenta ","Ochenta ", "Noventa "};


            string[] words3 = { "Mil ", "Lakh ", "Crore " };


            num[0] = number % 1000; // units
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2]; // thousands
            num[3] = number / 10000000; // crores
            num[2] = num[2] - 100 * num[3]; // lakhs


            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }

            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;


                u = num[i] % 10; // ones
                t = num[i] / 10;
                h = num[i] / 100; // hundreds
                t += -10 * h; // tens


                if (h > 0) sb.Append(h == 1 ? "" : words0[h] + "Cientos ");


                if (u > 0 || t > 0)
                {
                    //if (h > 0 || i == 0) sb.Append("y ");


                    // if (t == 0)//sb.Append(words0[u]);
                    if (t == 1)
                        sb.Append(words1[u]);
                    else if (t != 0)
                        sb.Append(words2[t - 2] + words0[u]);
                }


                if (i != 0) sb.Append(words3[i - 1]);


            }
            return sb.ToString().TrimEnd();
        }

    }
}
