using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pingo.Abstraction.Interfaces;
using Pingo.Models;

namespace Pingo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddressById(Guid id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAllAddresses()
        {
            var addresses = await _addressService.GetAllAddressesAsync();
            return Ok(addresses);
        }

        [HttpPost]
        public async Task<ActionResult> AddAddress(Address address)
        {
            await _addressService.AddAddressAsync(address);
            return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAddress(Guid id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            await _addressService.UpdateAddressAsync(address);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAddress(Guid id)
        {
            await _addressService.DeleteAddressAsync(id);
            return NoContent();
        }

    }
}