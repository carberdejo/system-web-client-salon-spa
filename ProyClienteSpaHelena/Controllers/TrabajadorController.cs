using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyClienteSpaHelena.Models;
using ProyClienteSpaHelena.Services;
using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Controllers
{
    public class TrabajadorController : Controller
    {
        private readonly TrabajadorService _trabajadorService;
        public TrabajadorController(TrabajadorService trabajadorService)
        {
            _trabajadorService = trabajadorService;
        }
        // GET: TrabajadorController
        public async Task<IActionResult> IndexTrabajador()
        {
            return View(await _trabajadorService.GetAllTrabajadorAsync());
        }

        // GET: TrabajadorController/Details/5
        public async Task<IActionResult> DetailsTrabajador(int id)
        {
            return View(await _trabajadorService.GetTrabajadorByIdAsync(id) );
        }

        // GET: TrabajadorController/Create
        public async Task<IActionResult> CreateTrabajador()
        {
            return View(await Task.Run(()=> new TrabajadorCreateDTO()));
        }

        // POST: TrabajadorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTrabajador(TrabajadorCreateDTO obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Trabajadora trabajador = await _trabajadorService.CreateTrabajadorAsync(obj);
                    return RedirectToAction(nameof(DetailsTrabajador), new { id = trabajador.Id });
                }
            }
            catch(Exception ex)
                {
                    ViewBag.error = "Hubo un error:"+ex;
            }
            return View(obj);
        }

        // GET: TrabajadorController/Edit/5
        public async Task<IActionResult> EditTrabajador(int id)
        {
            return View(await _trabajadorService.GetTrabajadorByIdAsync(id));
        }

        // POST: TrabajadorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTrabajador(int id, Trabajadora obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["message"] = await _trabajadorService.UpdateTrabajadorAsync(obj);
                    return RedirectToAction(nameof(IndexTrabajador));
                }
            }
            catch(Exception ex)
            {
                ViewBag.error = "Hubo un error al actualizar el trabajador: " + ex.Message;
            }
            
                return View(obj);    
        }

        // GET: TrabajadorController/Delete/5
        public async Task<IActionResult> DeleteTrabajador(int id)
        {
            return View(await _trabajadorService.GetTrabajadorByIdAsync(id));
        }

        // POST: TrabajadorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTrabajador(int id, IFormCollection collection)
        {
            try
            {
                TempData["message"] = await _trabajadorService.DeleteTrabajadorAsync(id);
                return RedirectToAction(nameof(IndexTrabajador));
            }
            catch(Exception ex)
            {
                ViewBag.error = "Hubo un error al eliminar el trabajador: " + ex.Message;
            }         
                return View();
        }
    }
}
