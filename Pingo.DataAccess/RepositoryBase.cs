using Microsoft.Data.SqlClient;
using Pingo.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pingo.DataAccess
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly string _connectionString;
        protected readonly string _tableName;

        public RepositoryBase(string connectionString, string tableName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
        }

        public async Task AddAsync(T entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var command = BuildInsertCommand(entity, connection);
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var command = new SqlCommand($"DELETE FROM {_tableName} WHERE Id = @Id", connection);
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
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
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
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var command = BuildUpdateCommand(entity, connection);
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

        protected SqlCommand BuildInsertCommand(T entity, SqlConnection connection)
        {
            var properties = typeof(T).GetProperties();
            var columns = new List<string>();
            var values = new List<string>();
            foreach (var prop in properties)
            {
                if (prop.Name != "Id")
                {
                    columns.Add(prop.Name);
                    values.Add($"@{prop.Name}");
                }
            }
            var command = new SqlCommand($"INSERT INTO {_tableName} ({string.Join(",", columns)}) VALUES ({string.Join(",", values)})", connection);
            foreach (var prop in properties)
            {
                if (prop.Name != "Id")
                {
                    command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(entity) ?? DBNull.Value);
                }
            }
            return command;
        }

        protected SqlCommand BuildUpdateCommand(T entity, SqlConnection connection)
        {
            var properties = typeof(T).GetProperties();
            var setClauses = new List<string>();
            foreach (var prop in properties)
            {
                if (prop.Name != "Id")
                {
                    setClauses.Add($"{prop.Name} = @{prop.Name}");
                }
            }
            var command = new SqlCommand($"UPDATE {_tableName} SET {string.Join(",", setClauses)} WHERE Id = @Id", connection);
            foreach (var prop in properties)
            {
                command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(entity) ?? DBNull.Value);
            }
            return command;
        }
    }
}
