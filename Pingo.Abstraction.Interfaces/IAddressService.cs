using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Abstraction.Interfaces
{
    public interface IAddressService
    {
        Task<Address> GetAddressByIdAsync(Guid addressId);
        Task<IEnumerable<Address>> GetAllAddressesAsync();
        Task<IEnumerable<Address>> GetAddressesByClientIdAsync(Guid clientId);
        Task AddAddressAsync(Address address);
        Task UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(Guid addressId);
    }
}
