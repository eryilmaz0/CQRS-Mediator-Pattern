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
    public class DapperEmployeeRepository : DapperRepositoryBase, IEmployeeDal
    {


        public DapperEmployeeRepository(IConfiguration configuration):base(configuration)
        {
            
        }


        public int Add(Employee employee)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                sqlConnection.Query<Employee>(@"INSERT INTO Employees ([Name],[LastName],[Gender],[AddressId],[DepartmentCode],[DepartmentName],[ReportsTo],[Created]) 
                                             VALUES (@Name,@LastName,@Gender,@AddressId,@DepartmentCode,@DepartmentName,@ReportsTo,@Created)",
                                             employee);
                CloseConnection(sqlConnection);
                return 1;
            }
        }





        public Employee Get(Func<Employee, bool> predicate)
        {
            List<Employee> employees;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                employees = sqlConnection.Query<Employee>("SELECT * FROM Employees").ToList();
                CloseConnection(sqlConnection);
            }

            return employees.FirstOrDefault(predicate);
        }





        public IList<Employee> GetAll()
        {
            List<Employee> employees;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                employees = sqlConnection.Query<Employee>("SELECT * FROM Employees").ToList();
                CloseConnection(sqlConnection);
            }

            return employees;
        }





        public int Remove(Employee employee)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                sqlConnection.Query<Employee>(@"DELETE FROM Employees WHERE Id = @Id", employee);
                CloseConnection(sqlConnection);
                return 1;
            }
        }





        public int Update(Employee employee)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                sqlConnection.Query<Employee>(@"UPDATE Employees SET [Name]=@Name, [LastName]=@LastName, [AddressId]=@AddressId, 
                                             [DepartmentCode]=@DepartmentCode, [DepartmentName]=@DepartmentName, [ReportsTo]=@ReportsTo 
                                             WHERE Id = @Id", employee);
                CloseConnection(sqlConnection);
                return 1;
            }
        }
    }
}