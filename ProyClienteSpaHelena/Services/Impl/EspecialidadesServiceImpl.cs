using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services.Impl
{
    public class EspecialidadesServiceImpl : EspecialidadService
    {
        private readonly HttpClient httpClient;
        public EspecialidadesServiceImpl(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<VariantesServicio> CreateEspecialidadesAsync(VariantesServicio variantesServicio)
        {
            var crear = await httpClient.PostAsJsonAsync("api/Especialidades", variantesServicio);
            if (crear.IsSuccessStatusCode)
            {
                var vserv = await crear.Content.ReadFromJsonAsync<VariantesServicio>();

                return vserv!;
            }
            else
            {
                var errorMessage = await crear.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear la variante: {errorMessage}");
            }
        }

        public async Task<string> DeleteEspecialidadesAsync(int id)
        {
            var resp = await httpClient.DeleteAsync($"api/Especialidades/{id}");
            string message = await resp.Content.ReadAsStringAsync();
            if (resp.IsSuccessStatusCode)
            {
                return message;
            }
            else
            {
                return $"Error al eliminar la variante: {message}";
            }

        }

        public Task<List<VariantesServicio>> GetAllEspecialidadesAsync()
        {
            return httpClient.GetFromJsonAsync<List<VariantesServicio>>("api/Especialidades")!;
        }

        public Task<VariantesServicio> GetEspecialidadesByIdAsync(int id)
        {
            return httpClient.GetFromJsonAsync<VariantesServicio>($"api/Especialidades/{id}")!;
        }

        public async Task<string> UpdateEspecialidadesAsync( VariantesServicio variantesServicio)
        {
            var actualizar = await httpClient.PutAsJsonAsync($"api/Especialidades", variantesServicio);
            string mensagge = await actualizar.Content.ReadAsStringAsync();
            {
                if (actualizar.IsSuccessStatusCode)
                {
                    return mensagge;
                }
                else
                {
                    return $"Error al actualizar la variante: {mensagge}";
                }
            }
            ;
        }
    }
}
