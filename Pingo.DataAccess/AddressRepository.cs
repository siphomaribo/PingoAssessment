using Microsoft.Data.SqlClient;
using Pingo.Abstraction.Interfaces;
using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Pingo.DataAccess
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(string connectionString) : base(connectionString, "tblAddress")
        {
        }

        private async Task<Guid> GetAddressTypeIdAsync(AddressTypeEnum addressType)
        {
            var command = new SqlCommand("SELECT Id FROM tblAddressType WHERE Type = @Type", _connection, _transaction);
            command.Parameters.AddWithValue("@Type", addressType.ToString());
            var result = await command.ExecuteScalarAsync();
            return (Guid)(result ?? Guid.Empty);
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

        public async Task AddAsync(Address address, Guid clientId)
        {
            var addressTypeId = await GetAddressTypeIdAsync(address.AddressType);

            var command = BuildInsertCommand(address, clientId, addressTypeId);
            await command.ExecuteNonQueryAsync();
        }

        private SqlCommand BuildInsertCommand(Address address, Guid clientId, Guid addressTypeId)
        {
            var command = new SqlCommand($"INSERT INTO {_tableName} (Id, ClientId, AddressTypeId, StreetAddress, City, Province, PostalCode, Country) VALUES (@Id, @ClientId, @AddressTypeId, @StreetAddress, @City, @State, @PostalCode, @Country)", _connection, _transaction);
            command.Parameters.AddWithValue("@Id", address.Id);
            command.Parameters.AddWithValue("@ClientId", clientId);
            command.Parameters.AddWithValue("@AddressTypeId", addressTypeId);
            command.Parameters.AddWithValue("@StreetAddress", address.StreetAddress ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@City", address.City ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@State", address.Province ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PostalCode", address.PostalCode ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Country", address.Country ?? (object)DBNull.Value);
            return command;
        }

    }
}
