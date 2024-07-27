using Pingo.Abstraction.Interfaces;
using Pingo.Models;
using System.Net;

namespace Pingo.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> GetClientByIdAsync(Guid clientId)
        {
            ValidateGuid(clientId);
            return await _unitOfWork.Clients.GetByIdAsync(clientId);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _unitOfWork.Clients.GetAllAsync();
        }

        public async Task AddClientAsync(Client client)
        {
            ValidateClient(client);
            _unitOfWork.BeginTransaction();

            try
            {
                client.Id = Guid.NewGuid();

                await _unitOfWork.Clients.AddAsync(client);

                if (client.Contacts != null)
                {
                    foreach (var contact in client.Contacts)
                    {
                        ValidateContact(contact);
                        await _unitOfWork.Contacts.AddAsync(contact, client.Id);
                    }
                }

                if (client.Addresses != null)
                {
                    foreach (var address in client.Addresses)
                    {
                        ValidateAddress(address);
                        await _unitOfWork.Addresses.AddAsync(address, client.Id);
                    }
                }

                await _unitOfWork.CompleteAsync();
            }
            catch
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task UpdateClientAsync(Client client)
        {
            ValidateClient(client);
            _unitOfWork.BeginTransaction();

            try
            {
                await _unitOfWork.Clients.UpdateAsync(client);
                await _unitOfWork.CompleteAsync();
            }
            catch
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task DeleteClientAsync(Guid clientId)
        {
            ValidateGuid(clientId);
            _unitOfWork.BeginTransaction();

            try
            {
                var client = await _unitOfWork.Clients.GetByIdAsync(clientId);
                if (client != null)
                {
                    if (client.Contacts != null)
                    {
                        foreach (var contact in client.Contacts)
                        {
                            await _unitOfWork.Contacts.DeleteAsync(contact);
                        }
                    }

                    if (client.Addresses != null)
                    {
                        foreach (var address in client.Addresses)
                        {
                            await _unitOfWork.Addresses.DeleteAsync(address);
                        }
                    }

                    await _unitOfWork.Clients.DeleteAsync(client);

                    await _unitOfWork.CompleteAsync();
                }
            }
            catch
            {
                _unitOfWork.RollbackTransaction();
                throw;
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

        private void ValidateAddress(Address address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            if (string.IsNullOrWhiteSpace(address.StreetAddress))
                throw new ArgumentException("Street address cannot be null or whitespace.");

            if (!Enum.IsDefined(typeof(AddressTypeEnum), address.AddressType))
                throw new ArgumentException("Invalid address type.");
        }

        private void ValidateContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            if (string.IsNullOrWhiteSpace(contact.Value))
                throw new ArgumentException("Contact value cannot be null or whitespace.");
        }
    }
}

