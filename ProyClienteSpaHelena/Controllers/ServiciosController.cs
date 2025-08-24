using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyClienteSpaHelena.Services;
using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly ServiciosService _servicioService;

        public ServiciosController(ServiciosService servicioService){
            _servicioService = servicioService;
            }
        // GET: ServiciosController
        public async Task< IActionResult> IndexServicio()
        {
            var serv = await _servicioService.GetAllServiciosAsync();
            return View(serv);
        }

        // GET: ServiciosController/Details/5
        public async Task<IActionResult> DetailsServ(int id)
        {
            return View( await _servicioService.GetServicioByIdAsync(id));
        }

        // GET: ServiciosController/Create
        public async Task<IActionResult> CreateServ()
        {
            Servicio servicio = await Task.Run(()=> new Servicio()) ;
            return View(servicio); 
        }

        // POST: ServiciosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  CreateServ(Servicio obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Servicio servicio = await _servicioService.CreateServicioAsync(obj);
                    return RedirectToAction(nameof(DetailsServ), new { id = servicio.Id });
                }
            }
            catch(Exception ex)
            {
                ViewBag.error = "Hubo un error al crear el servicio" +ex.Message;
                
            }
            return View(obj);
        }

        // GET: ServiciosController/Edit/5
        public async Task<IActionResult> EditServicios(int id)
        {
            return View(await _servicioService.GetServicioByIdAsync(id));
        }

        // POST: ServiciosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditServicios(int id, Servicio servicio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["mensaje"] = await _servicioService.UpdateServicioAsync(servicio);
                    return RedirectToAction(nameof(IndexServicio));
                }
            }
            catch(Exception ex)
            {
                ViewBag.error = "Hubo un error al crear el servicio" + ex.Message;
                
            }
            return View(servicio);
        }

        // GET: ServiciosController/Delete/5
        public async Task<IActionResult> DeleteServicio(int id)
        {
            return View(await _servicioService.GetServicioByIdAsync(id));
        }

        // POST: ServiciosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteServicio(int id, IFormCollection collection)
        {
            try
            {
                TempData["mensaje"] = await _servicioService.DeleteServicioAsync(id);
                return RedirectToAction(nameof(IndexServicio));
            }
            catch(Exception e)
            {
                ViewBag.mensaje = e.Message;
                
            }return View();
        }
    }
}
