using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services
{
    public interface HorarioService
    {
        Task<Disponibilidad> GetHorarioByIdAsync(int id);
    }
}
