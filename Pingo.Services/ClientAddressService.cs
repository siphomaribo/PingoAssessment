using Pingo.Abstraction.Interfaces;
using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Services
{
    public class ClientAddressService : IClientAddressService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRepository;

        public ClientAddressService(IClientRepository clientRepository, IAddressRepository addressRepository)
        {
            _clientRepository = clientRepository;
            _addressRepository = addressRepository;
        }

        public async Task AddClientAddressAsync(Guid clientId, Guid addressId)
        {
            ValidateGuid(clientId);
            ValidateGuid(addressId);

            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null)
                throw new ArgumentException("Client not found.");

            var address = await _addressRepository.GetByIdAsync(addressId);
            if (address == null)
                throw new ArgumentException("Address not found.");

            client.AddressIds.Add(addressId);
            await _clientRepository.UpdateAsync(client);
        }

        public async Task<IEnumerable<Address>> GetClientAddressesAsync(Guid clientId)
        {
            if (clientId == Guid.Empty)
                throw new ArgumentException("Client ID cannot be empty.", nameof(clientId));

            return await _addressRepository.GetAddressesByClientIdAsync(clientId);
        }

        public async Task RemoveClientAddressAsync(Guid clientId, Guid addressId)
        {
            ValidateGuid(clientId);
            ValidateGuid(addressId);

            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null)
                throw new ArgumentException("Client not found.");

            client.AddressIds.Remove(addressId);
            await _clientRepository.UpdateAsync(client);
        }

        private void ValidateGuid(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID cannot be empty.");
        }
    }
}
