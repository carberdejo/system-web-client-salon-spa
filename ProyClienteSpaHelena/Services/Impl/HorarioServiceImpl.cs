using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services.Impl
{
    public class HorarioServiceImpl : HorarioService
    {
        private HttpClient _httpClient;
        public HorarioServiceImpl(HttpClient httpClient) { 
            _httpClient = httpClient;
        }
        public Task<Disponibilidad> GetHorarioByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<Disponibilidad>($"api/Horario/{id}")!; 
        }
    }
}
