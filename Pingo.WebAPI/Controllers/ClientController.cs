using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pingo.Abstraction.Interfaces;
using Pingo.Models;

namespace Pingo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IClientAddressService _clientAddressService;
        private readonly IClientContactService _clientContactService;

        public ClientController(IClientService clientService, IClientAddressService clientAddressService, IClientContactService clientContactService)
        {
            _clientService = clientService;
            _clientAddressService = clientAddressService;
            _clientContactService = clientContactService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(Guid id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpPost]
        public async Task<ActionResult> AddClient(Client client)
        {
            await _clientService.AddClientAsync(client);
            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClient(Guid id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            await _clientService.UpdateClientAsync(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(Guid id)
        {
            await _clientService.DeleteClientAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/addresses")]
        public async Task<ActionResult<IEnumerable<Address>>> GetClientAddresses(Guid id)
        {
            var addresses = await _clientAddressService.GetClientAddressesAsync(id);
            return Ok(addresses);
        }

        [HttpGet("{id}/contacts")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetClientContacts(Guid id)
        {
            var contacts = await _clientContactService.GetClientContactsAsync(id);
            return Ok(contacts);
        }
    }
}
