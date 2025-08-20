using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services
{
    public interface ClienteService
    {
        // Define methods for the ClienteService interface
        Task<List<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task <string>CreateClienteAsync(Cliente cliente);
        Task <string>UpdateClienteAsync(int id, Cliente cliente);
        Task<bool> DeleteClienteAsync(int id);
    }
}
