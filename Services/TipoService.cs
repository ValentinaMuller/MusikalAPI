using MusikalAPI.Models;
using MusikalAPI.Interfaces;
using MusikalAPI.Context;

namespace MusikalAPI.Services
{
    public class TipoService : ITipoService
    {
        private readonly MusikalContext _context;

        public TipoService(MusikalContext context)
        {
            _context = context;
        }

        public List<Tipo> GetAll()
        {
            return _context.Tipos.ToList();
        }

        public Tipo GetById(int id)
        {
            return _context.Tipos.Find(id);
        }

        public Tipo Add(Tipo tipo)
        {
            _context.Tipos.Add(tipo);
            _context.SaveChanges();
            return tipo;
        }

        public Tipo Update(Tipo tipo, int id)
        {
            var _tipo = GetById(id);
            if (_tipo == null) return null;

            _tipo.Nombre = tipo.Nombre;

            _context.SaveChanges();
            return _tipo;
        }

        public bool Delete(int id)
        {
            var t = GetById(id);
            if (t == null) return false;
            _context.Tipos.Remove(t);
            _context.SaveChanges();
            return true;
        }
    }
}
