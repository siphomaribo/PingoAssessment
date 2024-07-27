using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Abstraction.Interfaces
{
    public interface IContactRepository : IRepositoryBase<Contact>
    {
        Task AddAsync(Contact contact, Guid clientId);
    }
}
