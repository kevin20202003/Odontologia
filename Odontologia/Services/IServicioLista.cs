using Microsoft.AspNetCore.Mvc.Rendering;

namespace Odontologia.Services
{
    public interface IServicioLista
    {
        Task<IEnumerable<SelectListItem>>
          GetListaContacto();
    }
}
