using Pingo.Abstraction.Interfaces;
using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Services
{
    public class ClientContactService : IClientContactService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IContactRepository _contactRepository;

        public ClientContactService(IClientRepository clientRepository, IContactRepository contactRepository)
        {
            _clientRepository = clientRepository;
            _contactRepository = contactRepository;
        }

        public async Task AddClientContactAsync(Guid clientId, Guid contactId)
        {
            ValidateGuid(clientId);
            ValidateGuid(contactId);

            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null)
                throw new ArgumentException("Client not found.");

            var contact = await _contactRepository.GetByIdAsync(contactId);
            if (contact == null)
                throw new ArgumentException("Contact not found.");

            client.ContactIds.Add(contactId);
            await _clientRepository.UpdateAsync(client);
        }

        public async Task<IEnumerable<Contact>> GetClientContactsAsync(Guid clientId)
        {
            if (clientId == Guid.Empty)
                throw new ArgumentException("Client ID cannot be empty.", nameof(clientId));

            return await _contactRepository.GetContactsByClientIdAsync(clientId);
        }

        public async Task RemoveClientContactAsync(Guid clientId, Guid contactId)
        {
            ValidateGuid(clientId);
            ValidateGuid(contactId);

            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null)
                throw new ArgumentException("Client not found.");

            client.ContactIds.Remove(contactId);
            await _clientRepository.UpdateAsync(client);
        }

        private void ValidateGuid(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID cannot be empty.");
        }
    }
}
