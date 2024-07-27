using Microsoft.Data.SqlClient;
using Pingo.Abstraction.Interfaces;
using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
        private SqlTransaction _transaction;

        public IClientRepository Clients { get; }
        public IAddressRepository Addresses { get; }
        public IContactRepository Contacts { get; }

        public UnitOfWork(string connectionString,
                          IClientRepository clientRepository,
                          IAddressRepository addressRepository,
                          IContactRepository contactRepository)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
            Clients = clientRepository;
            Addresses = addressRepository;
            Contacts = contactRepository;
        }

        public void BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            _transaction = _connection.BeginTransaction();
            AssignTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                _transaction?.Commit();
            }
            finally
            {
                _connection.Close();
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task CompleteAsync()
        {
            await CommitTransactionAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }

        private void AssignTransaction()
        {
            if (Clients is RepositoryBase<Client> clientRepo)
            {
                clientRepo.AssignTransaction(_connection, _transaction);
            }
            if (Addresses is RepositoryBase<Address> addressRepo)
            {
                addressRepo.AssignTransaction(_connection, _transaction);
            }
            if (Contacts is RepositoryBase<Contact> contactRepo)
            {
                contactRepo.AssignTransaction(_connection, _transaction);
            }
        }

        private async Task CommitTransactionAsync()
        {
            try
            {
                await _transaction?.CommitAsync();
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
