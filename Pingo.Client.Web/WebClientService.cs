using Pingo.Models;

namespace Pingo.Client.Web
{
    public class WebClientService : IWebClientService
    {
        private readonly HttpClient _httpClient;

        public WebClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Models.Client>> GetAllClientsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Models.Client>>("api/client");
        }

        public async Task<Models.Client> GetClientByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Models.Client>($"api/client/{id}");
        }

        public async Task AddClientAsync(Models.Client client)
        {
            await _httpClient.PostAsJsonAsync("api/client", client);
        }

        public async Task UpdateClientAsync(Models.Client client)
        {
            await _httpClient.PutAsJsonAsync("api/client", client);
        }

        public async Task DeleteClientAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/client/{id}");
        }

        public async Task ExportClientsToCsvAsync()
        {
            await _httpClient.GetAsync("api/client/Export");
            // Implementation for download link or notification if needed
        }
    }
}
