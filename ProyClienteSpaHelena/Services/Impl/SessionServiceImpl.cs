using ProySpaHelena.Models;
using Microsoft.AspNetCore.Http;
using ProyClienteSpaHelena.Models;
using Newtonsoft.Json;

namespace ProyClienteSpaHelena.Services.Impl
{
    public class SessionServiceImpl : SessionService
    {
        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SessionServiceImpl(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            this.httpClient = httpClient;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Login(LoginDTO loginDTO)
        {
            var user = await httpClient.PostAsJsonAsync("/login",loginDTO);

            if(!user.IsSuccessStatusCode)
            {
                var errorMessage = await user.Content.ReadAsStringAsync();
                return $"Error al iniciar sesión: {errorMessage}";
            }

            var userData = await user.Content.ReadFromJsonAsync<Trabajadora>();
           
            var usuario = JsonConvert.SerializeObject(userData);
            httpContextAccessor.HttpContext!.Session.SetString("Usuario", usuario);

            return $"{userData!.Nombre} registrado correctamente";
        }   
    }
}
