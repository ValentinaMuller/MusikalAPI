using Microsoft.AspNetCore.Mvc;
using MusikalAPI.Interfaces;
using MusikalAPI.Models;

namespace MusikalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcasController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet]
        public ActionResult<List<Marca>> GetAll()
        {
            var marcas = _marcaService.GetAll();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public ActionResult<Marca> GetById(int id)
        {
            var marca = _marcaService.GetById(id);
            if (marca == null)
                return NotFound($"No se encontró ninguna marca con el ID {id}.");
            return Ok(marca);
        }

        [HttpPost]
        public ActionResult<Marca> Add(Marca marca)
        {
            var nuevaMarca = _marcaService.Add(marca);
            return CreatedAtAction(nameof(GetById), new { id = nuevaMarca.Id }, nuevaMarca);
        }

        [HttpPut("{id}")]
        public ActionResult<Marca> Update(int id, Marca marca)
        {
            var marcaActualizada = _marcaService.Update(marca, id);
            if (marcaActualizada == null)
                return NotFound($"No se encontró ninguna marca con el ID {id} para actualizar.");
            return Ok(marcaActualizada);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var marca = _marcaService.GetById(id);
            if (marca == null)
                return NotFound($"No se encontró ninguna marca con el ID {id} para eliminar.");

            _marcaService.Delete(id);
            return NoContent();
        }
    }
}
