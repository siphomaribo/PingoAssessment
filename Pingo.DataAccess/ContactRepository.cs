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
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(string connectionString) : base(connectionString, "tblContact")
        {
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

        public async Task<IEnumerable<Contact>> GetContactsByClientIdAsync(Guid clientId)
        {
            var contacts = new List<Contact>();
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            await using var command = new SqlCommand(@"
                SELECT c.* FROM tblContact c
                INNER JOIN tblClientContact cc ON c.Id = cc.ContactId
                WHERE cc.ClientId = @ClientId", connection);
            command.Parameters.AddWithValue("@ClientId", clientId);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                contacts.Add(MapToEntity(reader));
            }
            return contacts;
        }
    }
}
