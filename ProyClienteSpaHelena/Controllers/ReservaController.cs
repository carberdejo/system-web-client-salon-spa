using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyClienteSpaHelena.Services;
using ProyClienteSpaHelena.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyClienteSpaHelena.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ReservaService reservaService;
        private readonly TrabajadorService trabajadorService;
        private readonly EspecialidadService especialidadService;
        private readonly ClienteService clienteService;
        public ReservaController(ReservaService reservaService, 
            TrabajadorService trabajadorService,EspecialidadService especialidadService,ClienteService clienteService)
        {
            this.reservaService = reservaService;
            this.trabajadorService = trabajadorService;
            this.especialidadService = especialidadService;
            this.clienteService = clienteService;
        }
        // GET: ReservaController
        public async Task<IActionResult> IndexReserva()
        {
            return View(await reservaService.GetReservasAsync());
        }

        // GET: ReservaController/Details/5
        public async Task<IActionResult> DetailsReserva(int id)
        {
            return View(await reservaService.GetReservaByIdAsync(id));
        }

        // GET: ReservaController/Create
        public async Task<IActionResult> CreateReserva()
        {
            ViewBag.trabajadores= new SelectList(await trabajadorService.GetAllTrabajadorAsync(), "Id", "Apellido");
            ViewBag.especialidades = new SelectList(await especialidadService.GetAllEspecialidadesAsync(), "Id", "Nombre");
            ViewBag.cliente = new SelectList(await clienteService.GetAllClientesAsync(), "Id", "NombreCompleto");

            return View(await Task.Run(()=>new ReservaRequestDto()));
        }

        // POST: ReservaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReserva(ReservaRequestDto obj)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var response = await reservaService.CreateReservaAsync(obj);
                    if (response != null)
                    {
                        TempData["Mensaje"] = "Reserva creada exitosamente.";
                    }
                    else
                    {
                        TempData["Mensaje"] = "Error al crear la reserva.";
                    }
                    
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = "Error al crear la reserva: " + ex.Message;
            }
            ViewBag.trabajadores = new SelectList(await trabajadorService.GetAllTrabajadorAsync(), "Id", "Apellido");
            ViewBag.especialidades = new SelectList(await especialidadService.GetAllEspecialidadesAsync(), "Id", "Nombre");
            ViewBag.cliente = new SelectList(await clienteService.GetAllClientesAsync(), "Id", "NombreCompleto");
            return View(obj);
        }

        // GET: ReservaController/Edit/5
        public async Task<IActionResult> EditReserva(int id)
        {
            return View();
        }

        // POST: ReservaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReserva(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
