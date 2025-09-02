using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyClienteSpaHelena.Security;
using ProyClienteSpaHelena.Services;
using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Controllers
{
    [AuthorizeSession]
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: ClienteController
        public async Task< IActionResult> IndexClientes()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            return View(clientes);
        }

        // GET: ClienteController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View( await _clienteService.GetClienteByIdAsync(id));
        }

        // GET: ClienteController/Create
        public async Task<IActionResult> CreateClientes()
        {
            Cliente cliente = await Task.Run(()=> new Cliente());
            return View(cliente);
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateClientes(Cliente obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cliente cli = await _clienteService.CreateClienteAsync(obj);

                    return RedirectToAction(nameof(Details),new { id = cli.Id});
                }
            }
            catch(Exception ex)
            {
                ViewBag.message = "Error al crear el cliente: " + ex.Message;
            }
            return View(obj);
        }

        // GET: ClienteController/Edit/5
        public async Task<IActionResult> EditClientes(int id)
        {
            return View(await _clienteService.GetClienteByIdAsync(id));
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditClientes(int id, Cliente obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["mensaje"] = await _clienteService.UpdateClienteAsync(id,obj);

                    return RedirectToAction(nameof(IndexClientes));
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = "Error al crear el cliente: " + ex.Message;
            }
            return View(obj);
        }

        // GET: ClienteController/Delete/5
        public async Task<IActionResult> DeleteClientes(int id)
        {
            return View(await _clienteService.GetClienteByIdAsync(id));
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteClientes(int id, IFormCollection collection)
        {
            try
            {
                TempData["mensaje"] = await _clienteService.DeleteClienteAsync(id);
                return RedirectToAction(nameof(IndexClientes));
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;

            }
            return View();
        }
    }
}
