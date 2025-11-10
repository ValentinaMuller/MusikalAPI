using MusikalAPI.Models;

namespace MusikalAPI.Interfaces
{
    public interface IMarcaService
    {
        Marca Add(Marca marca);
        Marca GetById(int id);
        List<Marca> GetAll();
        Marca Update(Marca marca, int id);
        bool Delete(int id);
    }
}