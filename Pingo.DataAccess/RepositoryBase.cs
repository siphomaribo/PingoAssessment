using Microsoft.Data.SqlClient;
using Pingo.Abstraction.Interfaces;
using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;
using System.Threading.Tasks;

namespace Pingo.DataAccess
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly string _connectionString;
        protected readonly string _tableName;
        protected SqlConnection _connection;
        protected SqlTransaction _transaction;

        public RepositoryBase(string connectionString, string tableName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
        }

        public async Task AddAsync(T entity)
        {
            if (_connection == null || _transaction == null)
            {
                throw new InvalidOperationException("Transaction or connection is not set.");
            }

            var command = BuildInsertCommand(entity);

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (_connection == null || _transaction == null)
            {
                throw new InvalidOperationException("Transaction or connection is not set.");
            }

            var command = new SqlCommand($"DELETE FROM {_tableName} WHERE Id = @Id", _connection, _transaction);
            command.Parameters.AddWithValue("@Id", GetIdFromEntity(entity));
            await command.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = new List<T>();

            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            await using var command = new SqlCommand($"SELECT * FROM {_tableName}", connection);
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                entities.Add(MapToEntity(reader));
            }
            return entities;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            await using var connection = GetConnection();
            await using var command = new SqlCommand($"SELECT * FROM {_tableName} WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            await using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return MapToEntity(reader);
            }
            return null;
        }

        public async Task UpdateAsync(T entity)
        {
            var command = BuildUpdateCommand(entity);
            await command.ExecuteNonQueryAsync();
        }

        protected virtual T MapToEntity(SqlDataReader reader)
        {
            throw new NotImplementedException("MapToEntity must be implemented in derived classes.");
        }

        protected Guid GetIdFromEntity(T entity)
        {
            return (Guid)entity.GetType().GetProperty("Id").GetValue(entity, null);
        }

        protected SqlCommand BuildInsertCommand(T entity)
        {
            var properties = typeof(T).GetProperties()
                   .Where(prop => !Attribute.IsDefined(prop, typeof(IgnoreForSqlAttribute)))
                   .ToArray();

            var columns = new List<string>();
            var values = new List<string>();

            foreach (var prop in properties)
            {
                columns.Add(prop.Name);
                values.Add($"@{prop.Name}");
            }

            var command = new SqlCommand($"INSERT INTO {_tableName} ({string.Join(",", columns)}) VALUES ({string.Join(",", values)})", _connection, _transaction);

            foreach (var prop in properties)
            {
                command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(entity) ?? DBNull.Value);
            }

            return command;
        }


        protected SqlCommand BuildUpdateCommand(T entity)
        {
            var properties = typeof(T).GetProperties()
                      .Where(prop => !Attribute.IsDefined(prop, typeof(IgnoreForSqlAttribute)))
                       .ToArray();


            var setClauses = new List<string>();
            foreach (var prop in properties)
            {
                if (prop.Name != "Id")
                {
                    setClauses.Add($"{prop.Name} = @{prop.Name}");
                }
            }
            var command = new SqlCommand($"UPDATE {_tableName} SET {string.Join(",", setClauses)} WHERE Id = @Id", _connection, _transaction);
            foreach (var prop in properties)
            {
                command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(entity) ?? DBNull.Value);
            }
            return command;
        }

        public void AssignTransaction(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        private SqlConnection GetConnection()
        {
            return _connection ?? new SqlConnection(_connectionString);
        }
    }
}
