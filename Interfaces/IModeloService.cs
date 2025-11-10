using MusikalAPI.Models;

namespace MusikalAPI.Interfaces
{
    public interface IModeloService
    {
        // CRUD Básico
        Modelo Add(Modelo modelo); 
        Modelo GetById(int id);
        List<Modelo> GetAll(); 
        Modelo Update(Modelo modelo, int id); 
        bool Delete(int id); 

        // Métodos adicionales específicos para Modelo
        IEnumerable<Modelo> GetByMarca(int idMarca); // Obtener Modelos por Marca
        IEnumerable<Modelo> GetByTipo(int idTipo); // Obtener Modelos por Tipo
    }
}