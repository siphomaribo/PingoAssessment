using Pingo.Abstraction.Interfaces;
using Pingo.Models;

namespace Pingo.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> GetClientByIdAsync(Guid clientId)
        {
            ValidateGuid(clientId);
            return await _clientRepository.GetByIdAsync(clientId);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task AddClientAsync(Client client)
        {
            ValidateClient(client);
            client.Id = Guid.NewGuid();
            await _clientRepository.AddAsync(client);
        }

        public async Task UpdateClientAsync(Client client)
        {
            ValidateClient(client);
            await _clientRepository.UpdateAsync(client);
        }

        public async Task DeleteClientAsync(Guid clientId)
        {
            ValidateGuid(clientId);
            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client != null)
            {
                await _clientRepository.DeleteAsync(client);
            }
        }

        private void ValidateClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            if (string.IsNullOrWhiteSpace(client.Name))
                throw new ArgumentException("Client name cannot be null or whitespace.");
        }

        private void ValidateGuid(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID cannot be empty.");
        }
    }
}
