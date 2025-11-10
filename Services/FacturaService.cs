using MusikalAPI.Models;
using MusikalAPI.Interfaces;
using MusikalAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace MusikalAPI.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly MusikalContext _context;

        public FacturaService(MusikalContext context)
        {
            _context = context;
        }

        public Factura CrearFactura(Factura factura)
        {
            // Establecer fecha actual si no se envió
            if (factura.FechaEmision == DateTime.MinValue)
            {
                factura.FechaEmision = DateTime.Now;
            }
            // Generar código de pago único (simulado)
            factura.CodigoPagoUnico = Guid.NewGuid().ToString();

            // Por defecto, el estado será "Pendiente"
            factura.Estado = "Pendiente";

            _context.Facturas.Add(factura);
            _context.SaveChanges();

            return factura;
        }

        public Factura GetById(int id)
        {
            return _context.Facturas.Find(id);
        }

        public List<Factura> GetAll()
        {
            return _context.Facturas.ToList();      
        }

        public Factura Update(Factura factura)
        {
            var _factura = GetById(factura.Id);
            if (_factura == null) return null;
            _factura.MontoTotal = factura.MontoTotal;
            _factura.IdCliente = factura.IdCliente;
            _factura.Estado = factura.Estado;

            _context.SaveChanges();
            return _factura;
        }

        public bool Delete(int id)
        {
            var f = GetById(id);
            if (f == null) return false;
            _context.Facturas.Remove(f);
            _context.SaveChanges();
            return true;
        }

        // Actualizar estado de pago (Pendiente / Pagada)
        public void ActualizarEstadoPago(int idFactura, string estadoPago)
        {
            var factura = _context.Facturas.FirstOrDefault(f => f.Id == idFactura);
            if (factura != null)
            {
                factura.Estado = estadoPago;
                _context.SaveChanges();
            }
        }

        // Listar facturas pendientes
        public IEnumerable<Factura> GetPendientes()
        {
            return _context.Facturas
                .Where(f => f.Estado == "Pendiente")
                .Include(f => f.Cliente)
                .ToList();
        }

        // Listar facturas pagadas
        public IEnumerable<Factura> GetPagadas()
        {
            return _context.Facturas
                .Where(f => f.Estado == "Pagada")
                .Include(f => f.Cliente)
                .ToList();
        }
    }
}
