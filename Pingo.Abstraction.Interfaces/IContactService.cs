using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Abstraction.Interfaces
{
    public interface IContactService
    {
        Task<Contact> GetContactByIdAsync(Guid contactId);
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<IEnumerable<Contact>> GetContactsByClientIdAsync(Guid clientId);
        Task AddContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(Guid contactId);
    }
}
