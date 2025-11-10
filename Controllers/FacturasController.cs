using Microsoft.AspNetCore.Mvc;
using MusikalAPI.Interfaces;
using MusikalAPI.Models;

namespace MusikalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturasController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpPost]
        public ActionResult<Factura> CrearFactura(Factura factura)
        {
            var nuevaFactura = _facturaService.CrearFactura(factura);
            return CreatedAtAction(nameof(GetById), new { id = nuevaFactura.Id }, nuevaFactura);
        }

        [HttpGet]
        public ActionResult<List<Factura>> GetAll()
        {
            var facturas = _facturaService.GetAll();
            return Ok(facturas);
        }

        [HttpGet("{id}")]
        public ActionResult<Factura> GetById(int id)
        {
            var factura = _facturaService.GetById(id);
            if (factura == null)
                return NotFound($"No se encontró la factura con ID {id}.");
            return Ok(factura);
        }

        [HttpPut("{id}")]
        public ActionResult<Factura> Update(int id, Factura factura)
        {
            if (id != factura.Id)
                return BadRequest("El ID de la factura no coincide.");

            var actualizada = _facturaService.Update(factura);
            if (actualizada == null)
                return NotFound($"No se encontró la factura con ID {id} para actualizar.");
            return Ok(actualizada);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eliminada = _facturaService.Delete(id);
            if (!eliminada)
                return NotFound($"No se encontró la factura con ID {id} para eliminar.");
            return NoContent();
        }

        // Cambiar estado de pago
        [HttpPut("{idFactura}/estado")]
        public IActionResult ActualizarEstadoPago(int idFactura, [FromQuery] string estadoPago)
        {
            _facturaService.ActualizarEstadoPago(idFactura, estadoPago);
            return Ok($"Estado de la factura {idFactura} actualizado a '{estadoPago}'.");
        }

        // Obtener facturas pendientes
        [HttpGet("pendientes")]
        public ActionResult<IEnumerable<Factura>> GetPendientes()
        {
            var pendientes = _facturaService.GetPendientes();
            return Ok(pendientes);
        }

        // Obtener facturas pagadas
        [HttpGet("pagadas")]
        public ActionResult<IEnumerable<Factura>> GetPagadas()
        {
            var pagadas = _facturaService.GetPagadas();
            return Ok(pagadas);
        }
    }
}
