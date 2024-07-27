using Microsoft.Data.SqlClient;
using Pingo.Abstraction.Interfaces;
using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Pingo.DataAccess
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(string connectionString) : base(connectionString, "tblContact")
        {
        }

        public async Task AddAsync(Contact contact, Guid clientId)
        {
            var contactTypeId = await GetContactTypeIdAsync(contact.ContactType);

            var command = BuildInsertCommand(contact, clientId, contactTypeId);
            await command.ExecuteNonQueryAsync();

        }

        private SqlCommand BuildInsertCommand(Contact contact, Guid clientId, Guid contactTypeId)
        {

            var command = new SqlCommand($"INSERT INTO {_tableName} (Id, ClientId, ContactTypeId, Value) VALUES (@Id, @ClientId, @ContactTypeId, @Value)", _connection, _transaction);
            command.Parameters.AddWithValue("@Id", contact.Id);
            command.Parameters.AddWithValue("@ClientId", clientId);
            command.Parameters.AddWithValue("@ContactTypeId", contactTypeId);
            command.Parameters.AddWithValue("@Value", contact.Value ?? (object)DBNull.Value);
            return command;
        }

        private async Task<Guid> GetContactTypeIdAsync(ContactTypeEnum contactType)
        {
            var command = new SqlCommand("SELECT Id FROM tblContactType WHERE Type = @Type", _connection, _transaction);
            command.Parameters.AddWithValue("@Type", contactType.ToString());
            var result = await command.ExecuteScalarAsync();
            return (Guid)(result ?? Guid.Empty);
        }

        protected override Contact MapToEntity(SqlDataReader reader)
        {
            return new Contact
            {
                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                ContactType = (ContactTypeEnum)Enum.Parse(typeof(ContactTypeEnum), reader.GetString(reader.GetOrdinal("ContactType"))),
                Value = reader.GetString(reader.GetOrdinal("Value"))
            };
        }
    }
}
