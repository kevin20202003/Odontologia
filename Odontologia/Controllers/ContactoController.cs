using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odontologia.Models;
using Odontologia.Models.Entidades;

namespace Odontologia.Controllers
{
    public class ContactoController : Controller
    {
        private readonly OdontologiaContext _context;

        public ContactoController(OdontologiaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListadoContactos()
        {
            return View(await _context.Contactos.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Contacto contacto)
        {

            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Contacto creado exitosamente";
                return RedirectToAction("ListadoContactos");

            }
            else
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido Un error");
            }



            return View();
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Contactos == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Contacto contacto)
        {
            if (id != contacto.id_contacto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Contacto actualizado " +
                        "exitosamente!!!";
                    return RedirectToAction("ListadoContactos");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(ex.Message, "Ocurrio un error " +
                        "al actualizar");
                }
            }
            return View(contacto);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Contactos == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos
                .FirstOrDefaultAsync(m => m.id_contacto == id);

            if (contacto == null)
            {
                return NotFound();
            }

            try
            {
                _context.Contactos.Remove(contacto);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Contacto eliminado exitosamente!!!";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");
            }

            return RedirectToAction(nameof(ListadoContactos));
        }
    }
}
