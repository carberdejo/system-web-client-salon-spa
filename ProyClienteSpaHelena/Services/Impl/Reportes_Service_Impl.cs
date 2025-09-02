using ProySpaHelena.Models;
using ProyClienteSpaHelena.Models;
using System.Net.Http;

namespace ProyClienteSpaHelena.Services.Impl
{
    public class Reportes_Service_Impl : Reportes_Service
    {

        private readonly HttpClient httpClient;

        public Reportes_Service_Impl(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public Task<List<Reporte_Servicio>> GetAllReporteServicio()
        {
            return httpClient.GetFromJsonAsync<List<Reporte_Servicio>>("api/Reportes/ReporteServicios")!;
        }

        public Task<List<Reporte_Trabajadores>> GetAllReporteTrabajador()
        {
            return httpClient.GetFromJsonAsync<List<Reporte_Trabajadores>>("api/Reportes/ReporteTrabajadores")!;
        }
    }
}
