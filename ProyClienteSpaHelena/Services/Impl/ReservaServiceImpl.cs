using ProyClienteSpaHelena.Models;

namespace ProyClienteSpaHelena.Services.Impl
{
    public class ReservaServiceImpl : ReservaService
    {
        private readonly HttpClient _httpClient;
        public ReservaServiceImpl(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ReservaResponseDTO> CreateReservaAsync(ReservaRequestDto reserva)
        {
            var crear = await _httpClient.PostAsJsonAsync("api/Reserva", reserva);
            if (crear.IsSuccessStatusCode)
            {
                var reservaCreada = await crear.Content.ReadFromJsonAsync<ReservaResponseDTO>();
                return reservaCreada!;
            }
            else
            {
                var errorMessage = crear.Content.ReadAsStringAsync().Result;
                throw new Exception($"Error al crear la reserva: {errorMessage}");
            }
        }

        public Task<ReservaResponseDTO> GetReservaByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<ReservaResponseDTO>($"api/Reserva/{id}")!;
        }

        public Task<IEnumerable<ReservaResponseDTO>> GetReservasAsync()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<ReservaResponseDTO>>("api/Reserva")!;
        }
    }
}
