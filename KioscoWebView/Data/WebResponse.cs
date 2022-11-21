using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KioscoWebView.Data
{
    public class WebResponse<T>
    {
        public string message { get; set; }
        public bool isSuccess { get; set; }
        public string statusCode { get; set; }
        public T body { get; set; }
    }


}
