namespace Pingo.Client.Web
{
    public interface IWebClientService
    {
        Task<List<Models.Client>> GetAllClientsAsync();
        Task<Models.Client> GetClientByIdAsync(Guid id);
        Task AddClientAsync(Models.Client client);
        Task UpdateClientAsync(Models.Client client);
        Task DeleteClientAsync(Guid id);
        Task ExportClientsToCsvAsync();
    }
}
