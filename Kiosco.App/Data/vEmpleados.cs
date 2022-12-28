using System.ComponentModel.DataAnnotations.Schema;

namespace Kiosco.App.Data
{
    public class vEmpleados
    {
        public string? idEmpleado { get; set; }
        public string? Empleado { get; set; }
        public string? EMP_PERSON_NUMBER { get; set; }
        public string? POSITION_NAME { get; set; }
        public string? SUP_NAME { get; set; }
        public string? EMAIL_ADDRESS { get; set; }
        public DateTime? START_DATE { get; set; }
        public string Sub_Email { get; set; }
    }
}
