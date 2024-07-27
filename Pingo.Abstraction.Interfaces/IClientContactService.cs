using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Abstraction.Interfaces
{
    public interface IClientContactService
    {
        Task AddClientContactAsync(Guid clientId, Guid contactId);
        Task RemoveClientContactAsync(Guid clientId, Guid contactId);
        Task<IEnumerable<Contact>> GetClientContactsAsync(Guid clientId);

    }
}
