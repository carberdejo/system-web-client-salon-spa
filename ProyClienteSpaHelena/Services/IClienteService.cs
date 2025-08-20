using ProySpaHelena.Models;

namespace ProyClienteSpaHelena.Services
{
    public class IClienteService : ClienteService
    {
        private readonly HttpClient httpClient;
        public IClienteService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<string> CreateClienteAsync(Cliente cliente)
        {
            var crear =  httpClient.PostAsJsonAsync("api/Clientes", cliente);
            return crear.ContinueWith(response =>
            {
                if (response.Result.IsSuccessStatusCode)
                {
                    return "Cliente creado exitosamente.";
                }
                else
                {
                    return "Error al crear el cliente.";
                }
            });

        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            var resp = await httpClient.DeleteAsync($"api/Clientes/{id}");
            return resp.IsSuccessStatusCode;
            
        }

        public  Task<List<Cliente>> GetAllClientesAsync()
        {
            return  httpClient.GetFromJsonAsync<List<Cliente>>("api/Clientes")!;
        }

        public Task<Cliente> GetClienteByIdAsync(int id)
        {
            return httpClient.GetFromJsonAsync<Cliente>($"api/Clientes/{id}")!;
        }

        public Task<string> UpdateClienteAsync(int id, Cliente cliente)
        {
            var actualizar = httpClient.PutAsJsonAsync($"api/Clientes/{id}", cliente);
            return actualizar.ContinueWith(response =>
            {
                if (response.Result.IsSuccessStatusCode)
                {
                    return "Cliente actualizado exitosamente.";
                }
                else
                {
                    return "Error al actualizar el cliente.";
                }
            });
        }
    }
}
