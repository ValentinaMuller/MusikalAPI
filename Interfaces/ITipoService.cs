using MusikalAPI.Models;

namespace MusikalAPI.Interfaces
{
    public interface ITipoService
    {
        Tipo Add(Tipo tipo);
        Tipo GetById(int id);
        List<Tipo> GetAll();
        Tipo Update(Tipo tipo, int id);
        bool Delete(int id);
    }
}