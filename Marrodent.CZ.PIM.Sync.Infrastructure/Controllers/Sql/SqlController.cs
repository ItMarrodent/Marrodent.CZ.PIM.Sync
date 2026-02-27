using System.Data;
using Dapper;
using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Sql;
using Microsoft.Data.SqlClient;

namespace Marrodent.CZ.PIM.Sync.Infrastructure.Controllers.Sql
{
    public sealed class SqlController <T> : ISqlController<T>
    {
        //Private
        private readonly SqlConnection _connection;

        //CTOR
        public SqlController(string connnectionString)
        {
            _connection = new SqlConnection(connnectionString);
        }

        //Public
        public async Task<T> Single(string query)
        {
            if (_connection.State != ConnectionState.Open) await _connection.OpenAsync();

            T result = await _connection.QueryFirstAsync<T>(query);

            if(_connection.State != ConnectionState.Closed) await _connection.CloseAsync();

            return result;
        }

        public async Task<ICollection<T>> List(string query)
        {
            if (_connection.State != ConnectionState.Open) await _connection.OpenAsync();

            ICollection<T> result = (await _connection.QueryAsync<T>(query)).ToList();

            if (_connection.State != ConnectionState.Closed) await _connection.CloseAsync();

            return result;
        }
    }
}
