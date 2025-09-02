using ProyClienteSpaHelena.Models;
using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services
{
    public interface TrabajadorService
    {
        Task<List<Trabajadora>> GetAllTrabajadorAsync();
        Task<List<Trabajadora>> GetAllTrabajadorWorkerAsync();
        Task<Trabajadora> GetTrabajadorByIdAsync(int id);
        Task<Trabajadora> CreateTrabajadorAsync(TrabajadorCreateDTO createDTO);
        Task<string> UpdateTrabajadorAsync(Trabajadora trabajadora);
        Task<string> DeleteTrabajadorAsync(int id);
        Task<Asistencia> RegisterAsistenciaAsync(Asistencia obj);
    }
}
