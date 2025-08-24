using ProyClienteSpaHelena.Models;
using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services
{
    public interface ReservaService
    {
        Task<IEnumerable<ReservaResponseDTO>> GetReservasAsync();
        Task<ReservaResponseDTO> GetReservaByIdAsync(int id);
        Task<ReservaResponseDTO> CreateReservaAsync(ReservaRequestDto reserva);
        
    }
}
