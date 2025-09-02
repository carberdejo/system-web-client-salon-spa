using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyClienteSpaHelena.Security;
using ProyClienteSpaHelena.Services;
using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Controllers
{
    [AuthorizeSession]
    public class EspecialidadesController : Controller
    {
        private readonly EspecialidadService _especialidadService;

        public EspecialidadesController(EspecialidadService especialidadService)
        {
            _especialidadService = especialidadService;
        }
        // GET: EspecialidadesController
        public async Task<IActionResult> IndexEspecialidades()
        {
            var vserv = await _especialidadService.GetAllEspecialidadesAsync();
            return View(vserv);
        }

        // GET: EspecialidadesController/Details/5
        public async Task<IActionResult> DetailsEspe(int id)
        {
            return View(await _especialidadService.GetEspecialidadesByIdAsync(id));
        }

        // GET: EspecialidadesController/Create
        public async Task<IActionResult> CreateEspecialidades()
        {
            VariantesServicio vserv = await Task.Run(() => new VariantesServicio());
            return View(vserv);
        }

        // POST: EspecialidadesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEspecialidades(VariantesServicio obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VariantesServicio vserv = await _especialidadService.CreateEspecialidadesAsync(obj);
                    return RedirectToAction(nameof(DetailsEspe), new { id = vserv.Id });
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Hubo un error al crear la variante" + ex.Message;

            }
            return View(obj);
        }

        // GET: EspecialidadesController/Edit/5
        public async Task<IActionResult> EditEspecialidad(int id)
        {
            return View(await _especialidadService.GetEspecialidadesByIdAsync(id));
        }

        // POST: EspecialidadesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEspecialidad(int id, VariantesServicio variantesServicio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["mensaje"] = await _especialidadService.UpdateEspecialidadesAsync(variantesServicio);
                    return RedirectToAction(nameof(IndexEspecialidades));
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Hubo un error al editar la variante" + ex.Message;

            }
            return View(variantesServicio);
        }

        // GET: EspecialidadesController/Delete/5
        public async Task<IActionResult> DeleteEspecialidad(int id)
        {
            return View(await _especialidadService.GetEspecialidadesByIdAsync(id));
        }

        // POST: EspecialidadesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEspecialidad(int id, IFormCollection collection)
        {
            try
            {
                TempData["mensaje"] = await _especialidadService.DeleteEspecialidadesAsync(id);
                return RedirectToAction(nameof(IndexEspecialidades));
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;

            }
            return View();
        }
    }
}
