using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pingo.Abstraction.Interfaces;
using Pingo.Models;

namespace Pingo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(Guid id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAllContacts()
        {
            var contacts = await _contactService.GetAllContactsAsync();
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<ActionResult> AddContact(Contact contact)
        {
            await _contactService.AddContactAsync(contact);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(Guid id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            await _contactService.UpdateContactAsync(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(Guid id)
        {
            await _contactService.DeleteContactAsync(id);
            return NoContent();
        }
    }
}
