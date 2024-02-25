using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Odontologia.Models;

namespace Odontologia.Services
{
    public class ServicioLista : IServicioLista
    {
        private readonly OdontologiaContext _context;

        public ServicioLista(OdontologiaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaContacto()
        {
            List<SelectListItem> list = await _context.Contactos.Select(x => new SelectListItem
            {
                Text = x.nombre,
                Value = $"{x.id_contacto}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un contacto...]",
                Value = "0"
            });

            return list;
        }
    }
}
