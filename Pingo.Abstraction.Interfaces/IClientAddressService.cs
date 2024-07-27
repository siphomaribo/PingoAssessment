using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Abstraction.Interfaces
{
    public interface IClientAddressService
    {
        Task AddClientAddressAsync(Guid clientId, Guid addressId);
        Task RemoveClientAddressAsync(Guid clientId, Guid addressId);
        Task<IEnumerable<Address>> GetClientAddressesAsync(Guid clientId);

    }
}
