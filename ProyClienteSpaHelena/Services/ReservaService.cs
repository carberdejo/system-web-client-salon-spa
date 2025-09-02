using ProyClienteSpaHelena.Models;
using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services
{
    public interface ReservaService
    {
        Task<IEnumerable<ReservaResponseDTO>> GetReservasAsync();
        Task<IEnumerable<ReservaResponseDTO>> GetReservasPendienteAsync();
        Task<IEnumerable<ReservaResponseDTO>> GetReservasProgresoAsync();
        Task<ReservaResponseDTO> GetReservaByIdAsync(int id);
        Task<string> CreateReservaAsync(ReservaRequestDto reserva);
        Task<ReservaResponseDTO> EstadoReservaAsync(int id, string estado);

    }
}
