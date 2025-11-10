using MusikalAPI.Models;

namespace MusikalAPI.Interfaces
{
    public interface IFacturaService
    {
        // CRUD básico
        Factura CrearFactura(Factura factura);
        Factura GetById(int id);
        List<Factura> GetAll();
        Factura Update(Factura factura);
        bool Delete(int id);

        //funciones adicionales
        void ActualizarEstadoPago(int idFactura, string estadoPago);
        IEnumerable<Factura> GetPendientes(); // Obtener facturas pendientes de pago
        IEnumerable<Factura> GetPagadas(); // Obtener facturas pagadas
    }
}