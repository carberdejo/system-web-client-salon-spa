using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Controllers
{
    public class SessionController : Controller
    {
        // GET: SessionController/Login
        public async Task<IActionResult> Login()
        {   
            return View(await Task.Run(()=>new Trabajadora()));
        }

        // POST: SessionController/Login
        [HttpPost]
        public ActionResult Login(Trabajadora obj)
        {
            
            if (ModelState.IsValid)
            {
                //Trabajadora registrado = log.ValidarUsuario(obj.cor_usu, obj.pass_usu);
                //if (registrado)
                //{

                //    Console.WriteLine("Email: " + obj.cor_usu);
                //    Console.WriteLine("Password: " + obj.pass_usu);
                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    ViewBag.Mensaje = "Usuario o contraseña incorrectos.";                   
                //}
            }
            return View(obj);
        }



        // GET: SessionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SessionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SessionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: SessionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SessionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: SessionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SessionController/Delete/5
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
