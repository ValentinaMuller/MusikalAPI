using MusikalAPI.Models;
using MusikalAPI.Interfaces;
using MusikalAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace MusikalAPI.Services
{
    public class ModeloService : IModeloService
    {
        private readonly MusikalContext _context;

        public ModeloService(MusikalContext context)
        {
            _context = context;
        }

        public List<Modelo> GetAll()
        {
            return _context.Modelos.ToList();
        }

        public Modelo GetById(int id)
        {
            return _context.Modelos.Find(id);
        }

        public Modelo Add(Modelo modelo)
        {
            modelo.Marca = null;
            modelo.Tipo = null;
            _context.Modelos.Add(modelo);
            _context.SaveChanges();
            return modelo;
        }

        public Modelo Update(Modelo modelo, int id)
        {
            var _modelo = GetById(id);
            if (_modelo == null) return null;

            _modelo.Nombre = modelo.Nombre;
            _modelo.Descripcion = modelo.Descripcion;
            _modelo.Precio = modelo.Precio;
            _modelo.StockDisponible = modelo.StockDisponible;
            _modelo.IdMarca = modelo.IdMarca;
            _modelo.IdTipo = modelo.IdTipo;

            _context.SaveChanges();
            return _modelo;
        }

        public bool Delete(int id)
        {
            var m = GetById(id);
            if (m == null) return false;
            _context.Modelos.Remove(m);
            _context.SaveChanges();
            return true;
            
        }

        public IEnumerable<Modelo> GetByMarca(int idMarca)
        {
            return _context.Modelos
                .Include(m => m.Marca)
                .Include(m => m.Tipo)
                .Where(m => m.IdMarca == idMarca)
                .ToList();
        }

        public IEnumerable<Modelo> GetByTipo(int idTipo)
        {
            return _context.Modelos
                .Include(m => m.Marca)
                .Include(m => m.Tipo)
                .Where(m => m.IdTipo == idTipo)
                .ToList();
        }
    }
}
