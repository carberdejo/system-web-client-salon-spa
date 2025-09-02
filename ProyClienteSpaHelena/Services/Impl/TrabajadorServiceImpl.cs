using Microsoft.AspNetCore.Http.HttpResults;
using ProyClienteSpaHelena.Models;
using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services.Impl
{
    public class TrabajadorServiceImpl : TrabajadorService
    {
        private readonly HttpClient httpClient;
        public TrabajadorServiceImpl(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Trabajadora> CreateTrabajadorAsync(TrabajadorCreateDTO createDTO)
        {
            var crear = await httpClient.PostAsJsonAsync("api/Trabajadora", createDTO);
            if (crear.IsSuccessStatusCode)
            {
                var trabajadora = await crear.Content.ReadFromJsonAsync<Trabajadora>();
                return trabajadora!;
            }
            else
            {
                var errorMessage = crear.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear el trabajador: {errorMessage}");
            }
        }

        public async Task<string> DeleteTrabajadorAsync(int id)
        {
            var resp = await httpClient.DeleteAsync($"api/Trabajadora/{id}");
            var message = await resp.Content.ReadAsStringAsync();
            if (resp.IsSuccessStatusCode)
            {
                return message;
            }
            else
            {
                return $"Error al eliminar el trabajador: {message}";
            }
        }

        public Task<List<Trabajadora>> GetAllTrabajadorAsync()
        {
            return httpClient.GetFromJsonAsync<List<Trabajadora>>("api/Trabajadora")!;
        }

        public async Task<Asistencia> RegisterAsistenciaAsync(Asistencia obj)
        {
            var crear = await httpClient.PostAsJsonAsync("api/Asistencia", obj);
            
            if (crear.IsSuccessStatusCode)
            {
                var asistencia = await crear.Content.ReadFromJsonAsync<Asistencia>();   
                return asistencia!;
            }
            else
            {
                var Message = await crear.Content.ReadAsStringAsync();
                throw new Exception( $"Error al registrar la asistencia: {Message}");
            }
        }

        public Task<Trabajadora> GetTrabajadorByIdAsync(int id)
        {
            return httpClient.GetFromJsonAsync<Trabajadora>($"api/Trabajadora/{id}")!;
        }

        public async Task<string> UpdateTrabajadorAsync(Trabajadora trabajadora)
        {
            var actualizar =await httpClient.PutAsJsonAsync($"api/Trabajadora", trabajadora);
            var message = await actualizar.Content.ReadAsStringAsync();
            if (actualizar.IsSuccessStatusCode)
            {
                return message;
            }
            else
            {
                return $"Error al actualizar el trabajador: {message}";
            }
        }

        public Task<List<Trabajadora>> GetAllTrabajadorWorkerAsync()
        {
            return httpClient.GetFromJsonAsync<List<Trabajadora>>("/worker")!;
        }
    }
}
