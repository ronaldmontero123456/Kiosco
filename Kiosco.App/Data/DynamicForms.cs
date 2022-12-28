namespace Kiosco.App.Data
{
    public class DynamicForms
    {
        public int FormID { get; set; }
        public string? Modulo { get; set; }
        public string? Valor { get; set; }
        public string? Tipo { get; set; }
        public string? DestinationValue { get; set; }
        public string? DisplayValue { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public string FormAdminID { get; set; }
        public string? Question { get; set; }
        public string? PlaceHolder { get; set; }
    }
}
