namespace MusikalAPI.Models;

public class Modelo
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Precio { get; set; }
    public int StockDisponible { get; set; }
    public int IdMarca { get; set; }
    public Marca Marca { get; set; }
    public int IdTipo { get; set; }
    public Tipo Tipo { get; set; }
    
}
