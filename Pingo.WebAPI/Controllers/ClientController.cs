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
        private readonly ICSvService _cSvService;
        public ClientController(IClientService clientService, ICSvService cSvService)
        {
            _clientService = clientService;
            _cSvService = cSvService;
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

        [HttpPut]
        public async Task<ActionResult> UpdateClient(Client client)
        {
            await _clientService.UpdateClientAsync(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(Guid id)
        {
            await _clientService.DeleteClientAsync(id);
            return NoContent();
        }

        [HttpGet("Export")]
        public async Task<ActionResult> ExportCSv()
        {
            try
            {
                await _cSvService.ExportClientsToCsvAsync("clients_export.csv");

                return Ok();
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }
    }
}
