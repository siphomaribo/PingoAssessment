using Microsoft.Data.SqlClient;
using Pingo.Abstraction.Interfaces;
using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.DataAccess
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(string connectionString) : base(connectionString, "tblAddress")
        {
        }

        protected override Address MapToEntity(SqlDataReader reader)
        {
            return new Address
            {
                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                AddressType = (AddressTypeEnum)Enum.Parse(typeof(AddressTypeEnum), reader.GetString(reader.GetOrdinal("AddressType"))),
                StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress")),
                City = reader.GetString(reader.GetOrdinal("City")),
                Province = reader.GetString(reader.GetOrdinal("State")),
                PostalCode = reader.GetString(reader.GetOrdinal("PostalCode")),
                Country = reader.GetString(reader.GetOrdinal("Country"))
            };
        }

        public async Task<IEnumerable<Address>> GetAddressesByClientIdAsync(Guid clientId)
        {
            var addresses = new List<Address>();
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            await using var command = new SqlCommand(@"
                SELECT a.* FROM tblAddress a
                INNER JOIN tblClientAddress ca ON a.Id = ca.AddressId
                WHERE ca.ClientId = @ClientId", connection);
            command.Parameters.AddWithValue("@ClientId", clientId);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                addresses.Add(MapToEntity(reader));
            }
            return addresses;
        }
    }
}
