using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTProSL_MSTest.DataLayer
{
    public interface IDBService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(string connectionString, string query, params object[] parameters);
        Task<T> GetByIdAsync<T>(string connectionString, string query, object id, params object[] parameters);
        Task InsertAsync(string connectionString, string query, params object[] parameters);
        Task UpdateAsync(string connectionString, string query, params object[] parameters);
        Task DeleteAsync(string connectionString, string query, object id, params object[] parameters);
    }
}
