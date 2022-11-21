using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KioscoWebView.Data
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
        public int DealerId { get; set; }
        public string DealerName { get; set; }
    }
}
