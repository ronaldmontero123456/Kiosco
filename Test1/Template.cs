using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Template
    {
        [Key]
        public int TemplateID { get; set; }
        public int TemplateData { get; set; }
    }
}
