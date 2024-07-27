using Pingo.Abstraction.Interfaces;
using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> GetContactByIdAsync(Guid contactId)
        {
            ValidateGuid(contactId);
            return await _contactRepository.GetByIdAsync(contactId);
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _contactRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Contact>> GetContactsByClientIdAsync(Guid clientId)
        {
            ValidateGuid(clientId);
            return await _contactRepository.GetContactsByClientIdAsync(clientId);
        }

        public async Task AddContactAsync(Contact contact)
        {
            ValidateContact(contact);
            contact.Id = Guid.NewGuid();
            await _contactRepository.AddAsync(contact);
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            ValidateContact(contact);
            await _contactRepository.UpdateAsync(contact);
        }

        public async Task DeleteContactAsync(Guid contactId)
        {
            ValidateGuid(contactId);
            var contact = await _contactRepository.GetByIdAsync(contactId);
            if (contact != null)
            {
                await _contactRepository.DeleteAsync(contact);
            }
        }

        private void ValidateContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            if (string.IsNullOrWhiteSpace(contact.Value))
                throw new ArgumentException("Contact value cannot be null or whitespace.");
        }

        private void ValidateGuid(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID cannot be empty.");
        }
    }
}
