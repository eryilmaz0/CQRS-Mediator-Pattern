using SolidPractice.DataAccess.Abstract;
using SolidPractices.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SolidPractice.DataAccess.Dapper
{
    public class DapperAddressRepository : DapperRepositoryBase, IAddressDal
    {

        public DapperAddressRepository(IConfiguration configuration):base(configuration)
        {
            
        }


        public int Add(Address address)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                sqlConnection.Query<Address>(@"INSERT INTO Addresses ([Country],[City],[PostCode],[Created]) 
                                             VALUES (@Country,@City,@PostCode,@Created)",
                                            address);
                CloseConnection(sqlConnection);
                return 1;
            }
        }




        public Address Get(Func<Address, bool> predicate)
        {
            List<Address> adresses;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                adresses = sqlConnection.Query<Address>("SELECT * FROM Addresses").ToList();
                CloseConnection(sqlConnection);
            }

            return adresses.FirstOrDefault(predicate);
        }




        public IList<Address> GetAll()
        {
            List<Address> adresses;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                adresses = sqlConnection.Query<Address>("SELECT * FROM Addresses").ToList();
                CloseConnection(sqlConnection);
            }

            return adresses;
        }




        public int Remove(Address address)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                sqlConnection.Query<Address>(@"DELETE FROM Addresses WHERE Id = @Id", address);
                CloseConnection(sqlConnection);
                return 1;
            }
        }




        public int Update(Address address)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                sqlConnection.Query<Address>(@"UPDATE Addresses SET [Country]=@Country, [City]=@City, [PostCode]=@PostCode 
                                             WHERE Id = @Id",address);
                CloseConnection(sqlConnection);
                return 1;
            }
        }


    }
}