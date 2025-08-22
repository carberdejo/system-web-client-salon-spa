using ProySpaHelena.Models;
using Microsoft.AspNetCore.Http;

namespace ProyClienteSpaHelena.Services.Impl
{
    public class SessionServiceImpl : SessionService
    {
        private readonly HttpClient httpClient;
        
        public SessionServiceImpl(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> Login(string email, string password)
        {
            //var user= await httpClient.GetFromJsonAsync<Trabajadora>($"api/Trabajadoras/Login?email={email}&password={password}")!;

            //if(user == null)
            //{
            //    return $"El usaurio con email {email} es incorrecto";
            //}
            //HttpContext.Session.SetString("user", user.Email);
            return null;
        }
    }
}
