using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTProSL_MSTest.DataLayer
{
    public class DBService : IDBService
    {
        public async Task<IEnumerable<T>> GetAllAsync<T>(string connectionString, string query, params object[] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<T>(query, parameters);
                return result;
            }
        }

        public async Task<T> GetByIdAsync<T>(string connectionString, string query, object id, params object[] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QueryFirstOrDefaultAsync<T>(query, new { id });
                return result;
            }
        }

        public async Task InsertAsync(string connectionString, string query, params object[] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateAsync(string connectionString, string query, params object[] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteAsync(string connectionString, string query, object id, params object[] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
