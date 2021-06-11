using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SolidPractice.DataAccess.Abstract;
using SolidPractices.Entities.Entities;

namespace SolidPractice.DataAccess.Dapper
{
    public class DapperSupplierRepository : DapperRepositoryBase, ISupplierDal
    {


        public DapperSupplierRepository(IConfiguration configuration) : base(configuration)
        {

        }




        public IList<Supplier> GetAll()
        {
            List<Supplier> suppliers;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                suppliers = sqlConnection.Query<Supplier>("SELECT * FROM Suppliers").ToList();
                CloseConnection(sqlConnection);
            }

            return suppliers;
        }





        public Supplier Get(Func<Supplier, bool> predicate)
        {
            List<Supplier> suppliers;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                suppliers = sqlConnection.Query<Supplier>("SELECT * FROM Suppliers").ToList();
                CloseConnection(sqlConnection);
            }

            return suppliers.FirstOrDefault(predicate);
        }





        public int Add(Supplier supplier)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                sqlConnection.Query<Supplier>(@"INSERT INTO Suppliers ([Name],[LastName],[Gender],[AddressId],[CompanyName],[Fax],[Created]) 
                                              VALUES (@Name,@LastName,@Gender,@AddressId,@CompanyName,@Fax,@Created)",
                                              supplier);
                CloseConnection(sqlConnection);
                return 1;
            }
        }





        public int Remove(Supplier supplier)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                sqlConnection.Query<Supplier>(@"DELETE FROM Suppliers WHERE Id = @Id", supplier);
                CloseConnection(sqlConnection);
                return 1;
            }
        }





        public int Update(Supplier supplier)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                sqlConnection.Query<Supplier>(@"UPDATE Suppliers SET [Name]=@Name, [LastName]=@LastName, [AddressId]=@AddressId, 
                                              [CompanyName]=@CompanyName, [Fax]=@Fax 
                                             WHERE Id = @Id", supplier);
                CloseConnection(sqlConnection);
                return 1;
            }
        }
    }
}