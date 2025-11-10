using Microsoft.AspNetCore.Mvc;
using MusikalAPI.Interfaces;
using MusikalAPI.Models;

namespace MusikalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelosController : ControllerBase
    {
        private readonly IModeloService _modeloService;

        public ModelosController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Modelo>> GetAll()
        {
            return Ok(_modeloService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Modelo> GetById(int id)
        {
            var modelo = _modeloService.GetById(id);
            if (modelo == null) return NotFound();
            return Ok(modelo);
        }

        [HttpGet("marca/{idMarca}")]
        public ActionResult<IEnumerable<Modelo>> GetByMarca(int idMarca)
        {
            return Ok(_modeloService.GetByMarca(idMarca));
        }

        [HttpGet("tipo/{idTipo}")]
        public ActionResult<IEnumerable<Modelo>> GetByTipo(int idTipo)
        {
            return Ok(_modeloService.GetByTipo(idTipo));
        }

        [HttpPost]
        public ActionResult<Modelo> Add(Modelo modelo)
        {
            var nuevo = _modeloService.Add(modelo);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public ActionResult<Modelo> Update(int id, Modelo modelo)
        {
            var actualizado = _modeloService.Update(modelo, id);
            if (actualizado == null) return NotFound();
            return Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _modeloService.Delete(id);
            return NoContent();
        }
    }
}
