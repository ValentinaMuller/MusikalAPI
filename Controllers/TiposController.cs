using Microsoft.AspNetCore.Mvc;
using MusikalAPI.Interfaces;
using MusikalAPI.Models;

namespace MusikalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposController : ControllerBase
    {
        private readonly ITipoService _tipoService;

        public TiposController(ITipoService tipoService)
        {
            _tipoService = tipoService;
        }

        [HttpGet]
        public ActionResult<List<Tipo>> GetAll()
        {
            var tipos = _tipoService.GetAll();
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public ActionResult<Tipo> GetById(int id)
        {
            var t = _tipoService.GetById(id);
            if (t == null)
                return NotFound($"No se encontró ningún tipo con el ID {id}.");
            return Ok(t);
        }

        [HttpPost]
        public ActionResult<Tipo> Add(Tipo tipo)
        {
            var nuevoTipo = _tipoService.Add(tipo);
            return CreatedAtAction(nameof(GetById), new { id = nuevoTipo.Id }, nuevoTipo);
        }

        [HttpPut("{id}")]
        public ActionResult<Tipo> Update(int id, Tipo tipo)
        {
            var t = _tipoService.Update(tipo, id);
            if (t == null)
                return NotFound($"No se encontró ningún tipo con el ID {id} para actualizar.");
            return Ok(t);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var t = _tipoService.GetById(id);
            if (t == null)
                return NotFound($"No se encontró ningún tipo con el ID {id} para eliminar.");

            _tipoService.Delete(id);
            return NoContent();
        }
    }
}
