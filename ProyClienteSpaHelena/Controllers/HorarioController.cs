using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyClienteSpaHelena.Security;
using ProyClienteSpaHelena.Services;

namespace ProyClienteSpaHelena.Controllers
{
    [AuthorizeSession]
    public class HorarioController : Controller
    {
        private readonly HorarioService horarioService;
        public HorarioController(HorarioService _horarioService)
        {
            horarioService = _horarioService;
        }



        // GET: HorarioController/Details/5
        public async Task<IActionResult> HorarioId(int id)
        {
            return View(await horarioService.GetHorarioByIdAsync(id));
        }

        // GET: HorarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HorarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HorarioController/Create
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

        // GET: HorarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HorarioController/Edit/5
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

        // GET: HorarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HorarioController/Delete/5
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
