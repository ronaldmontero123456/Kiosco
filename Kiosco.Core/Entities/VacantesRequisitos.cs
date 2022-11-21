using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kiosco.Core.Entities
{
    public class VacantesRequisitos
    {
        public int VacantesRequisitosId { get; set; }
        public int VacanteId { get; set; }
        public string Requisitos { get; set; }
        //public virtual Vacantes Vacante { get; set; }
    }
}
