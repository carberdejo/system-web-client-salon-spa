using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services
{
    public interface SessionService
    {
        Task<string> Login(string email,string password);
    }
}
