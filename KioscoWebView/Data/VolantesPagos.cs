using System.Text.Json.Serialization;

namespace KioscoWebView.Data;
public class VolantesPagos
{
    public VolantesPagosItem[] items { get; set; }
    public bool hasMore { get; set; }
    public int limit { get; set; }
    public int offset { get; set; }
    public int count { get; set; }
}

public class VolantesPagosItem
{
    public int codigo { get; set; }
    public string nombres { get; set; }
    public string apellidos { get; set; }
    public string cedula { get; set; }
    public int salario { get; set; }
    public DateTime fecha_ingreso { get; set; }
    public string numero_cuenta_banco { get; set; }
    public string cargo { get; set; }
    public string depto { get; set; }
    public string descripcion { get; set; }
    public string tipo { get; set; }
    public float monto { get; set; }
    public float ingreso { get; set; }
    public float descuento { get; set; }
    public object precio { get; set; }
    public float? cant_horas { get; set; }
    public int? saldo { get; set; }
    public int id_mov { get; set; }
}


