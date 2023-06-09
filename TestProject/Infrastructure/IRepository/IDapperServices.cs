using Dapper;
using System.Data;

namespace TestProject.Infrastructure.IRepository
{
    public interface IDapperServices : IDisposable
    {
        T Get<T>(String sp, DynamicParameters parms, 
            CommandType commandType = CommandType.StoredProcedure);

        List <T> GetAll<T>(String sp, DynamicParameters parms,
           CommandType commandType = CommandType.StoredProcedure);

        int ExecuteScaler<T>(String sp, DynamicParameters parms,
           CommandType commandType = CommandType.StoredProcedure);
    }
}
