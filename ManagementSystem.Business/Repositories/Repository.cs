using ManagementSystem.Business.Repositories.Interfaces;
using System.Data.SqlClient;

namespace ManagementSystem.Business.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly string _connString;

        public Repository(string connString)
        {
            _connString = connString;
        }

        public async Task<string?> ExecuteProcedureReturnStringAsync(string procName, params SqlParameter[] paramters)
        {
            string? result = "";
            using (var sqlConnection = new SqlConnection(_connString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = procName;
                    if (paramters != null)
                    {
                        command.Parameters.AddRange(paramters);
                    }
                    sqlConnection.Open();
                    var ret = await command.ExecuteScalarAsync();
                    if (ret != null)
                        result = Convert.ToString(ret);
                }
            }
            return result;
        }

        public async Task<T> ExtecuteProcedureReturnDataAsync(string procName, Func<SqlDataReader, T> translator, params SqlParameter[] parameters)
        {
            using (var sqlConnection = new SqlConnection(_connString))
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = procName;
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters);
                    }
                    sqlConnection.Open();
                    using (var reader = await sqlCommand.ExecuteReaderAsync())
                    {
                        T elements;
                        try
                        {
                            elements = translator(reader);
                        }
                        finally
                        {
                            while (reader.NextResult())
                            { }
                        }
                        return elements;
                    }
                }
            }
        }

        public async Task<IEnumerable<T>> ExtecuteProcedureReturnDataAsync(string procName, Func<SqlDataReader, IEnumerable<T>> translator, params SqlParameter[] parameters)
        {
            using (var sqlConnection = new SqlConnection(_connString))
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = procName;
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters);
                    }
                    sqlConnection.Open();
                    using (var reader = await sqlCommand.ExecuteReaderAsync())
                    {
                        IEnumerable<T> elements;
                        try
                        {
                            elements = translator(reader);
                        }
                        finally
                        {
                            while (reader.NextResult())
                            { }
                        }
                        return elements;
                    }
                }
            }
        }
    }
}
