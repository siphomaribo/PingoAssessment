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
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(string connectionString) : base(connectionString, "tblClient")
        {
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var clientDictionary = new Dictionary<Guid, Client>();

            var query = @"
        SELECT 
            c.Id AS ClientId, c.Name, c.Surname, c.Gender, c.DateOfBirth,
            ct.Id AS ContactId, ct.Value AS ContactValue, ctt.Type AS ContactType,
            a.Id AS AddressId, a.StreetAddress, a.City, a.Province, a.PostalCode, a.Country, att.Type AS AddressType
        FROM tblClient c
        LEFT JOIN tblContact ct ON c.Id = ct.ClientId
        LEFT JOIN tblContactType ctt ON ct.ContactTypeId = ctt.Id
        LEFT JOIN tblAddress a ON c.Id = a.ClientId
        LEFT JOIN tblAddressType att ON a.AddressTypeId = att.Id";

            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            await using var command = new SqlCommand(query, connection);
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var clientId = reader.GetGuid(reader.GetOrdinal("ClientId"));

                if (!clientDictionary.TryGetValue(clientId, out var client))
                {
                    client = new Client
                    {
                        Id = clientId,
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Surname = reader.GetString(reader.GetOrdinal("Surname")),
                        Gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? null : reader.GetString(reader.GetOrdinal("Gender")),
                        DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                        Contacts = new List<Contact>(),
                        Addresses = new List<Address>()
                    };
                    clientDictionary[clientId] = client;
                }

                // Populate Contacts
                if (!reader.IsDBNull(reader.GetOrdinal("ContactId")))
                {
                    var contactTypeString = reader.GetString(reader.GetOrdinal("ContactType"));
                    ContactTypeEnum contactType;

                    // Attempt to parse the contact type string into the enum
                    if (!Enum.TryParse(contactTypeString, out contactType))
                    {
                        contactType = ContactTypeEnum.Unknown;
                    }

                    client.Contacts.Add(new Contact
                    {
                        Id = reader.GetGuid(reader.GetOrdinal("ContactId")),
                        Value = reader.GetString(reader.GetOrdinal("ContactValue")),
                        ContactType = contactType,
                        // Add other fields if necessary
                    });
                }

                // Populate Addresses
                if (!reader.IsDBNull(reader.GetOrdinal("AddressId")))
                {
                    var addressTypeString = reader.GetString(reader.GetOrdinal("AddressType"));
                    AddressTypeEnum addressType;

                    // Attempt to parse the contact type string into the enum
                    if (!Enum.TryParse(addressTypeString, out addressType))
                    {
                        addressType = AddressTypeEnum.Unknown;
                    }

                    client.Addresses.Add(new Address
                    {
                        Id = reader.GetGuid(reader.GetOrdinal("AddressId")),
                        StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress")),
                        City = reader.GetString(reader.GetOrdinal("City")),
                        Province = reader.GetString(reader.GetOrdinal("Province")),
                        PostalCode = reader.GetString(reader.GetOrdinal("PostalCode")),
                        Country = reader.GetString(reader.GetOrdinal("Country")),
                        AddressType = addressType,
                    });
                }
            }

            return clientDictionary.Values;
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            var clientDictionary = new Dictionary<Guid, Client>();

            var query = @"
        SELECT 
            c.Id AS ClientId, c.Name, c.Surname, c.Gender, c.DateOfBirth,
            ct.Id AS ContactId, ct.Value AS ContactValue, ctt.Type AS ContactType,
            a.Id AS AddressId, a.StreetAddress, a.City, a.Province, a.PostalCode, a.Country, att.Type AS AddressType
        FROM tblClient c
        LEFT JOIN tblContact ct ON c.Id = ct.ClientId
        LEFT JOIN tblContactType ctt ON ct.ContactTypeId = ctt.Id
        LEFT JOIN tblAddress a ON c.Id = a.ClientId
        LEFT JOIN tblAddressType att ON a.AddressTypeId = att.Id
        WHERE c.Id = @ClientId";

            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientId", id);

            await using var reader = await command.ExecuteReaderAsync();

            Client client = null;

            while (await reader.ReadAsync())
            {
                var clientId = reader.GetGuid(reader.GetOrdinal("ClientId"));

                if (client == null)
                {
                    client = new Client
                    {
                        Id = clientId,
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Surname = reader.GetString(reader.GetOrdinal("Surname")),
                        Gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? null : reader.GetString(reader.GetOrdinal("Gender")),
                        DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                        Contacts = new List<Contact>(),
                        Addresses = new List<Address>()
                    };
                }

                // Populate Contacts
                if (!reader.IsDBNull(reader.GetOrdinal("ContactId")))
                {
                    var contactTypeString = reader.GetString(reader.GetOrdinal("ContactType"));
                    ContactTypeEnum contactType;

                    if (!Enum.TryParse(contactTypeString, out contactType))
                    {
                        contactType = ContactTypeEnum.Unknown;
                    }

                    client.Contacts.Add(new Contact
                    {
                        Id = reader.GetGuid(reader.GetOrdinal("ContactId")),
                        Value = reader.GetString(reader.GetOrdinal("ContactValue")),
                        ContactType = contactType,
                        // Add other fields if necessary
                    });
                }

                // Populate Addresses
                if (!reader.IsDBNull(reader.GetOrdinal("AddressId")))
                {
                    var addressTypeString = reader.GetString(reader.GetOrdinal("AddressType"));
                    AddressTypeEnum addressType;

                    if (!Enum.TryParse(addressTypeString, out addressType))
                    {
                        addressType = AddressTypeEnum.Unknown;
                    }

                    client.Addresses.Add(new Address
                    {
                        Id = reader.GetGuid(reader.GetOrdinal("AddressId")),
                        StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress")),
                        City = reader.GetString(reader.GetOrdinal("City")),
                        Province = reader.GetString(reader.GetOrdinal("Province")),
                        PostalCode = reader.GetString(reader.GetOrdinal("PostalCode")),
                        Country = reader.GetString(reader.GetOrdinal("Country")),
                        AddressType = addressType,
                    });
                }
            }

            return client;
        }

        protected override Client MapToEntity(SqlDataReader reader)
        {
            return new Client
            {
                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? null : reader.GetString(reader.GetOrdinal("Gender")),
                DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? null : reader.GetDateTime(reader.GetOrdinal("DateOfBirth"))
                // You'll need to fetch the AddressIds and ContactIds separately
            };
        }
    }
}
