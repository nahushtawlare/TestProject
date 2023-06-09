using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using TestProject.Infrastructure.IRepository;

namespace TestProject.Infrastructure.Repository
{
    public class DapperServices : IDapperServices
    {
        private readonly IConfiguration config;
        private string Connectionstring = "DefaultConnection";

        public DapperServices(IConfiguration config)
        {
            this.config = config;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int ExecuteScaler<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(this.config.GetConnectionString(Connectionstring));
            return db.Execute(sp, parms, commandType: commandType);
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(this.config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(this.config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }
    }
}
