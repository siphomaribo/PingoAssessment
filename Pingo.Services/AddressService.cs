using Pingo.Abstraction.Interfaces;
using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Address> GetAddressByIdAsync(Guid addressId)
        {
            ValidateGuid(addressId);
            return await _addressRepository.GetByIdAsync(addressId);
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            return await _addressRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Address>> GetAddressesByClientIdAsync(Guid clientId)
        {
            ValidateGuid(clientId);
            return await _addressRepository.GetAddressesByClientIdAsync(clientId);
        }

        public async Task AddAddressAsync(Address address)
        {
            ValidateAddress(address);
            address.Id = Guid.NewGuid();
            await _addressRepository.AddAsync(address);
        }

        public async Task UpdateAddressAsync(Address address)
        {
            ValidateAddress(address);
            await _addressRepository.UpdateAsync(address);
        }

        public async Task DeleteAddressAsync(Guid addressId)
        {
            ValidateGuid(addressId);
            var address = await _addressRepository.GetByIdAsync(addressId);
            if (address != null)
            {
                await _addressRepository.DeleteAsync(address);
            }
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

        private void ValidateGuid(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID cannot be empty.");
        }
    }
}
