using Odontologia.Models.Entidades;

namespace Odontologia.Services
{
    public interface IServicioContacto
    {
        Task<Contacto> GetContacto(string nombre, string email);
        Task<Contacto> SaveContacto(Contacto Autor);
    }
}
