using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public ContactTypeEnum ContactType { get; set; }
        public string Value { get; set; }
    }
}
