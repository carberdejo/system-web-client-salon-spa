using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyClienteSpaHelena.Services;
using ProyClienteSpaHelena.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyClienteSpaHelena.Security;

namespace ProyClienteSpaHelena.Controllers
{
    [AuthorizeSession]
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

        // GET: ReservaPendientController
        public async Task<IActionResult> IndexReservaPendiente()
        {
            return View(await reservaService.GetReservasPendienteAsync());

        }
        // GET: ReservaPendientController
        public async Task<IActionResult> IndexReservaProgreso()
        {
            return View(await reservaService.GetReservasProgresoAsync());
        }

        // GET: ReservaController/Details/5
        public async Task<IActionResult> DetailsReserva(int id)
        {
            return View(await reservaService.GetReservaByIdAsync(id));
        }

        // GET: ReservaController/Create
        public async Task<IActionResult> CreateReserva()
        {
            ViewBag.trabajadores = new SelectList(await trabajadorService.GetAllTrabajadorWorkerAsync(), "Id", "Nombre");
            ViewBag.trabajadoresDisponibles= new SelectList(await trabajadorService.GetAllTrabajadorAsync(), "Id", "Nombre");
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
                    if (obj.Detalles == null)
                        throw new Exception("Detalles es null");

                    if (obj.Detalles.Count == 0)
                        throw new Exception("No hay detalles enviados");
                    Console.WriteLine("RESERVA enviados: " + obj.ClienteId,
                        obj.RecepcionistaId,obj.TrabajadoraId,obj.Fecha,obj.Notas);
                    Console.WriteLine("detalle enviados: " + obj.Detalles.Count);

                    var response = await reservaService.CreateReservaAsync(obj);

                    TempData["Mensaje"] = response;
                    return RedirectToAction("Index","Home");
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
            }
            ViewBag.trabajadores = new SelectList(await trabajadorService.GetAllTrabajadorWorkerAsync(), "Id", "Nombre");
            ViewBag.trabajadoresDisponibles = new SelectList(await trabajadorService.GetAllTrabajadorAsync(), "Id", "Nombre");
            ViewBag.especialidades = new SelectList(await especialidadService.GetAllEspecialidadesAsync(), "Id", "Nombre");
            ViewBag.cliente = new SelectList(await clienteService.GetAllClientesAsync(), "Id", "NombreCompleto");
            return View(obj);
        }

        // GET: ReservaController/CambiarEstadoReserva
        public async Task<IActionResult> CambiarEstadoReserva(int id)
        {
            return View(await reservaService.GetReservaByIdAsync(id));

        }
        [HttpPost]
        public async Task<IActionResult> CambiarEstadoReserva(int id, string estado)
        {
            try
            {
                
                var update = await reservaService.EstadoReservaAsync(id, estado);
                TempData["mensaje"] = $"La reserva {update.Id} ha sido cambiada a {update.Estado}";
                if (estado.ToLower() == "completada")
                {
                    return RedirectToAction(nameof(DetailsReserva),new {id=update.Id});
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.message = "Error:" + ex.Message;
            }

            return View(await reservaService.GetReservaByIdAsync(id));
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
