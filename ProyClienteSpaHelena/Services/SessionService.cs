using ProyClienteSpaHelena.Models;
using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services
{
    public interface SessionService
    {
        Task<string> Login(LoginDTO loginDTO);
    }
}
