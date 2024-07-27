using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Abstraction.Interfaces
{
    public interface IAddressRepository : IRepositoryBase<Address>
    {
        Task<IEnumerable<Address>> GetAddressesByClientIdAsync(Guid clientId);

    }
}
