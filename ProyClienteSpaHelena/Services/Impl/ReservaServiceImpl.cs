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
        public async Task<string> CreateReservaAsync(ReservaRequestDto reserva)
        {
            var crear = await _httpClient.PostAsJsonAsync("api/Reserva", reserva);
            
            if (crear.IsSuccessStatusCode)
            {
                var reservaCreada = await crear.Content.ReadFromJsonAsync<ReservaResponseDTO>();
                return $"La reserva n° {reservaCreada!.Id} ha sido creada";
            }
            else
            {
                var errorMessage = crear.Content.ReadAsStringAsync().Result;
                return $"Error al crear la reserva: {errorMessage}";
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
        public async Task<ReservaResponseDTO> EstadoReservaAsync(int id, string estado)
        {
            var update = await _httpClient.PutAsJsonAsync($"api/Reserva/{id}/Estado", estado);
            if (update.IsSuccessStatusCode)
            {
                var mensagge = await update.Content.ReadFromJsonAsync<ReservaResponseDTO>();
                return mensagge!;
            }
            else
            {
                var errorMessage = await update.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear el cliente: {errorMessage}");
            }
        }

        public Task<IEnumerable<ReservaResponseDTO>> GetReservasPendienteAsync()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<ReservaResponseDTO>>("api/Reserva/Pendiente")!;
        }

        public Task<IEnumerable<ReservaResponseDTO>> GetReservasProgresoAsync()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<ReservaResponseDTO>>("api/Reserva/Progreso")!;
        }
    }
}
