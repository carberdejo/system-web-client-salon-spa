using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services.Impl
{
    public class ServiciosServiceImpl : ServiciosService
    {
        private readonly HttpClient httpClient;
        public ServiciosServiceImpl(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Servicio> CreateServicioAsync(Servicio servicio)
        {
            var crear = await httpClient.PostAsJsonAsync("api/Servicio", servicio);
            if (crear.IsSuccessStatusCode)
            {
                var serv = await crear.Content.ReadFromJsonAsync<Servicio>();

                return serv!;
            }
            else
            {
                var errorMessage = await crear.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear el cliente: {errorMessage}");
            }
        }

        public async Task<string> DeleteServicioAsync(int id)
        {
            var resp = await httpClient.DeleteAsync($"api/Servicio/{id}");
            string message = await resp.Content.ReadAsStringAsync();
            if (resp.IsSuccessStatusCode)
            {
                return message;
            }
            else
            {
                return $"Error al eliminar el servicio: {message}";
            }

        }

        public Task<List<Servicio>> GetAllServiciosAsync()
        {
            return httpClient.GetFromJsonAsync<List<Servicio>>("api/Servicio")!;
        }

        public Task<Servicio> GetServicioByIdAsync(int id)
        {
            return httpClient.GetFromJsonAsync<Servicio>($"api/Servicio/{id}")!;
        }

        public async Task<string> UpdateServicioAsync(Servicio servicio)
        {
            var actualizar = await httpClient.PutAsJsonAsync($"api/Servicio", servicio);
            string mensagge = await actualizar.Content.ReadAsStringAsync();
            {
                if (actualizar.IsSuccessStatusCode)
                {
                    return mensagge;
                }
                else
                {
                    return $"Error al actualizar el servicio: {mensagge}";
                }
            }
            ;
        }
    }
}

