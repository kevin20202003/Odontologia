using Microsoft.EntityFrameworkCore;
using Odontologia.Models;
using Odontologia.Models.Entidades;

namespace Odontologia.Services
{
    public class ServicioContacto : IServicioContacto
    {
        private readonly OdontologiaContext _context;

        public ServicioContacto(OdontologiaContext context)
        {
            _context = context;
        }

        public async Task<Contacto> GetContacto(string nombre, string email)
        {
            Contacto contacto = await _context.Contactos.Where(u => u.nombre == nombre && u.email == email).FirstOrDefaultAsync();

            return contacto;
        }

        public async Task<Contacto> SaveContacto(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();
            return contacto;
        }
    }
}
