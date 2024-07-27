using Pingo.Abstraction.Interfaces;
using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Services
{
    public class CSvService : ICSvService
    {
        private readonly IClientService _clientService;

        public CSvService(IClientService clientService)
        {
            _clientService = clientService;
        }
        internal string ConvertClientsToCsv(IEnumerable<Client> clients)
        {
            var sb = new StringBuilder();

            // Define the CSV header.
            sb.AppendLine("ClientId,Name,Surname,Gender,DateOfBirth,StreetAddress,City,Province,PostalCode,Country");

            // Loop through each client and their addresses to build CSV rows.
            foreach (var client in clients)
            {
                foreach (var address in client.Addresses)
                {
                    sb.AppendLine($"{client.Id},{client.Name},{client.Surname},{client.Gender},{client.DateOfBirth?.ToString("yyyy-MM-dd")},{address.StreetAddress},{address.City},{address.Province},{address.PostalCode},{address.Country}");
                }
            }

            return sb.ToString();
        }

        public async Task ExportClientsToCsvAsync(string filePath)
        {
            var clients = await _clientService.GetAllClientsWithAddressesAsync();

            var csvData = ConvertClientsToCsv(clients);

            await File.WriteAllTextAsync(filePath, csvData);
        }
    }
}
