using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyClienteSpaHelena.Models;
using ProyClienteSpaHelena.Services;
using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Controllers
{
    public class SessionController : Controller
    {
        private readonly SessionService _sessionService;
        
        public SessionController(SessionService sessionService)
        {
            _sessionService = sessionService;
            
        }
        // GET: SessionController/Login
        public async Task<IActionResult> Login()
        {   
            return View(await Task.Run(()=>new LoginDTO()));
        }

        // POST: SessionController/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mensaje = await _sessionService.Login(obj);
                    if(mensaje.StartsWith("Error"))
                    {
                        ViewBag.mensaje = mensaje;
                        return View(obj);
                    }
                    TempData["Mensaje"] = mensaje;
                    return RedirectToAction("Index", "Home");
                }               
            }
            catch(Exception ex)
            {
                ViewBag.mensaje = $"Error al iniciar sesión: {ex.Message}";
            } 
            return View(obj);
        }

        [HttpPost]
        public IActionResult Logout(LoginDTO obj)
        {
            _sessionService.Logout();
            return RedirectToAction(nameof(Login));
        }



    }
}
