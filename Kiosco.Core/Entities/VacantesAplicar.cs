

namespace Kiosco.Core.Entities
{
    public class VacantesAplicar
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string? EmpName { get; set; }
        public int VacanteId { get; set; }
        public byte[]? FirmImg { get; set; }
    }
}
