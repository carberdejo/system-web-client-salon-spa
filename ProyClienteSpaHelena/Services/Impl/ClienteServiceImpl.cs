using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services.Impl
{
    public class ClienteServiceImpl : ClienteService
    {
        private readonly HttpClient httpClient;
        public ClienteServiceImpl(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Cliente> CreateClienteAsync(Cliente cliente)
        {
            var crear = await httpClient.PostAsJsonAsync("api/Clientes", cliente);
            if (crear.IsSuccessStatusCode)
            {
                var cli = await crear.Content.ReadFromJsonAsync<Cliente>();

                return cli!;
            }
            else
            {
                var errorMessage = await crear.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear el cliente: {errorMessage}");
            }
        }

        public async Task<string> DeleteClienteAsync(int id)
        {
            var resp = await httpClient.DeleteAsync($"api/Clientes/{id}");
            string message = await resp.Content.ReadAsStringAsync();
            if (resp.IsSuccessStatusCode)
            {
                return message;
            }
            else
            {
                return $"Error al eliminar el cliente: {message}";
            }

        }

        public Task<List<Cliente>> GetAllClientesAsync()
        {
            return httpClient.GetFromJsonAsync<List<Cliente>>("api/Clientes")!;
        }

        public Task<Cliente> GetClienteByIdAsync(int id)
        {
            return httpClient.GetFromJsonAsync<Cliente>($"api/Clientes/{id}")!;
        }

        public async Task<string> UpdateClienteAsync(int id, Cliente cliente)
        {
            var actualizar = await httpClient.PutAsJsonAsync($"api/Clientes/{id}", cliente);
            string mensagge = await actualizar.Content.ReadAsStringAsync();
            {
                if (actualizar.IsSuccessStatusCode)
                {
                    return mensagge;
                }
                else
                {
                    return $"Error al actualizar el cliente: {mensagge}";
                }
            };
        }
    }
}
