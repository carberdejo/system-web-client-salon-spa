using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyClienteSpaHelena.Security;
using ProyClienteSpaHelena.Services;

namespace ProyClienteSpaHelena.Controllers
{
    [AuthorizeSession]
    public class ReporteController : Controller
    {
        private readonly Reportes_Service _reportes_Service;

        public ReporteController(Reportes_Service reportes_Service)
        {
            _reportes_Service = reportes_Service;
        }

        // GET: ReporteController/ReporteServicios
        public async Task<IActionResult> ReporteServicios()
        {
            return View(await _reportes_Service.GetAllReporteServicio());
        }

        // GET: ReporteController/ReporteTrabajadores
        public async Task<IActionResult> ReporteTrabajadores()
        {
            return View(await _reportes_Service.GetAllReporteTrabajador());
        }
    }
}
