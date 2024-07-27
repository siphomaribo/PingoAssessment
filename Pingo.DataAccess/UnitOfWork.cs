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
            if (_transaction != null)
            {
                throw new InvalidOperationException("Transaction already started.");
            }
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            _transaction = _connection.BeginTransaction();
            AssignTransaction();
        }

        public void CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction started.");
            }
            if (_transaction.Connection == null)
            {
                throw new InvalidOperationException("Transaction has already been committed or rolled back.");
            }
            try
            {
                _transaction.Commit();
            }
            finally
            {
                _connection.Close();
            }
        }

        public void RollbackTransaction()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction started.");
            }
            if (_transaction.Connection == null)
            {
                throw new InvalidOperationException("Transaction has already been committed or rolled back.");
            }
            try
            {
                _transaction.Rollback();
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
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
            if (_connection != null)
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
                _connection = null;
            }
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
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction started.");
            }
            try
            {
                await _transaction.CommitAsync();
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
