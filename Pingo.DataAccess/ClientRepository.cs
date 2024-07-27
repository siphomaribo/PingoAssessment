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
