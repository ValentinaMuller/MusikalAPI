using MusikalAPI.Models;
using MusikalAPI.Interfaces;
using MusikalAPI.Context;

namespace MusikalAPI.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly MusikalContext _context;

        public MarcaService(MusikalContext context)
        {
            _context = context;
        }

        //Implementacion de métodos 
        public Marca Add(Marca marca)
        {
            _context.Marcas.Add(marca);
            _context.SaveChanges();
            return marca;
        }

        public Marca GetById(int id)
        {
            return _context.Marcas.Find(id);       }

        public List<Marca> GetAll()
        {
            return _context.Marcas.ToList();
        }

        public Marca Update(Marca marca, int id)
        {
            var _marca = GetById(id);
            if (_marca == null) return null;

            _marca.Nombre = marca.Nombre;
            _marca.PaisOrigen = marca.PaisOrigen;

            _context.SaveChanges();
            return _marca;
        }

        public bool Delete(int id)
        {
            var m = GetById(id);
            if (m == null) return false;
            _context.Marcas.Remove(m);
            _context.SaveChanges();
            return true;
            
        }
    }
}
