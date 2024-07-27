using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Models
{
    public class Address
    {
        public Guid Id { get; set; }

        [IgnoreForSqlAttribute]
        public AddressTypeEnum AddressType { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string   Country   { get; set; }
    }
}
