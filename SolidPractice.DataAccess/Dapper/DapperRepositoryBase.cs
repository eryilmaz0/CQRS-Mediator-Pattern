using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SolidPractice.DataAccess.Dapper
{
    public abstract class DapperRepositoryBase
    {
        protected string _connectionString;


        public DapperRepositoryBase(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }


        
        protected void OpenConnection(IDbConnection dbConnection)
        {
            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Open();
            }
        }


        
        protected void CloseConnection(IDbConnection dbConnection)
        {
            if (dbConnection.State == ConnectionState.Open)
            {
                dbConnection.Close();
            }
        }
    }
}