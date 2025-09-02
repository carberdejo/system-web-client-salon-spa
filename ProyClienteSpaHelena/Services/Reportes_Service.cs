using ProyClienteSpaHelena.Models;
using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services
{
    public interface Reportes_Service
    {
        Task<List<Reporte_Servicio>> GetAllReporteServicio();
        Task<List<Reporte_Trabajadores>> GetAllReporteTrabajador();

    }
}
