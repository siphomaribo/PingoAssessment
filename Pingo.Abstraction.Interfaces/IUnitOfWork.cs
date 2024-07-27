using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Abstraction.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }
        IAddressRepository Addresses { get; }
        IContactRepository Contacts { get; }
        Task CompleteAsync();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
