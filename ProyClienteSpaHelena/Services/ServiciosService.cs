using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services
     
{
    public interface ServiciosService
    {
        Task<List<Servicio>> GetAllServiciosAsync();
        Task<Servicio> GetServicioByIdAsync(int id);
        Task<Servicio> CreateServicioAsync(Servicio servicio);
        Task<string> UpdateServicioAsync( Servicio servicio);
        Task<string> DeleteServicioAsync(int id);
    }
}
