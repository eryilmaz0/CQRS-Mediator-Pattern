using SolidPractice.DataAccess.Abstract;
using SolidPractices.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SolidPractice.DataAccess.Dapper
{
    public class DapperCustomerRepository : DapperRepositoryBase, ICustomerDal
    {

        public DapperCustomerRepository(IConfiguration configuration):base(configuration)
        {
            
        }



        public int Add(Customer customer)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                sqlConnection.Query<Customer>(@"INSERT INTO Customers ([Name],[LastName],[Gender],[AddressId],[CustomerType],[Created]) 
                                             VALUES (@Name,@LastName,@Gender,@AddressId,@CustomerType,@Created)",
                    customer);
                CloseConnection(sqlConnection);
                return 1;
            }
        }




        public Customer Get(Func<Customer, bool> predicate)
        {
            List<Customer> customers;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                customers = sqlConnection.Query<Customer>("SELECT * FROM Customers").ToList();
                CloseConnection(sqlConnection);
            }

            return customers.FirstOrDefault(predicate);
        }




        public IList<Customer> GetAll()
        {
            List<Customer> customers;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                customers = sqlConnection.Query<Customer>("SELECT * FROM Customers").ToList();
                CloseConnection(sqlConnection);
            }

            return customers;
        }




        public int Remove(Customer customer)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                sqlConnection.Query<Customer>(@"DELETE FROM Customers WHERE Id = @Id", customer);
                CloseConnection(sqlConnection);
                return 1;
            }
        }




        public int Update(Customer customer)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                sqlConnection.Query<Customer>(@"UPDATE Customers SET [Name]=@Name, [LastName]=@LastName, [AddressId]=@AddressId, [CustomerType]=@CustomerType 
                                              WHERE Id = @Id", customer);
                CloseConnection(sqlConnection);
                return 1;
            }
        }
    }
}