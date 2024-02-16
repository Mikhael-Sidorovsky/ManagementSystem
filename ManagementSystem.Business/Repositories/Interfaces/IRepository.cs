using System.Data.SqlClient;

namespace ManagementSystem.Business.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<string?> ExecuteProcedureReturnStringAsync(string procName, params SqlParameter[] paramters);

        Task<T> ExtecuteProcedureReturnDataAsync(string procName, Func<SqlDataReader, T> translator, params SqlParameter[] parameters);

        Task<IEnumerable<T>> ExtecuteProcedureReturnDataAsync(string procName, Func<SqlDataReader, IEnumerable<T>> translator, params SqlParameter[] parameters);
    }
}