namespace MusikalAPI.Models;

public class Factura
{
    public int Id { get; set; }
    public DateTime FechaEmision { get; set; }
    public int IdCliente { get; set; }
    public Cliente Cliente { get; set; }
    public int MontoTotal { get; set; }
    public string CodigoPagoUnico { get; set; }
    public string Estado { get; set; }
}
