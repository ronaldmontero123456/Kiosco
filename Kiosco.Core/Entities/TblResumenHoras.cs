using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Core.Entities
{
    public class TblResumenHoras
    {
        public int idResumenHoras { get; set; }
        public int idArchivosResumenHoras { get; set; }
        public DateTime? HFNOM { get; set; }
        public string? HCODE { get; set; }
        public DateTime? HFTRAN { get; set; }
        public double? HNORM { get; set; }
        public double? HEXT35 { get; set; }
        public double? HEXT100 { get; set; }
        public double? HSAB { get; set; }
        public double? HDOM { get; set; }
        public double? HFER { get; set; }
        public double? HNONE { get; set; }
        public double? HNOCT { get; set; }
        public double? HNONE2 { get; set; }
    }
}
