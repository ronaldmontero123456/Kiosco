using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DPWCMSApp.Model
{
    public class AuthenticateRequest
    {
        //[Required(ErrorMessage = "e-mail es requerido")]
        //[EmailAddress(ErrorMessage = "La dirección de e-mail es inválida")]
        //[Display(Name = "E-mail")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "se requiere contraseña")]
        //[DataType(DataType.Password)]
        //[StringLength(100, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.", MinimumLength = 8)]
        //[Display(Name = "Contraseña")]
        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Las contraseñas deben tener al menos 8 caracteres y contener 3 de 4 de los siguientes: mayúsculas (A-Z), minúsculas (a-z), números (0-9) y caracteres especiales (por ejemplo,! @ # $% ^ & *)")]

        public string Password { get; set; }
    }
}
