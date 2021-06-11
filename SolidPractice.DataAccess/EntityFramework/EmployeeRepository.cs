using System;
using System.Collections.Generic;
using System.Linq;
using SolidPractice.DataAccess.Abstract;
using SolidPractices.Entities;
using SolidPractices.Entities.Entities;

namespace SolidPractice.DataAccess.EntityFramework
{
    public class EmployeeRepository : IEmployeeDal
    {


        public IList<Employee> GetAll()
        {
            using (var _context = new SolidPracticeDbContext())
            {
                return _context.Employees.ToList();
            }
        }

        public Employee Get(Func<Employee, bool> predicate)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                return _context.Employees.FirstOrDefault(predicate);
            }
        }

        public int Add(Employee employee)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                 _context.Employees.Add(employee);
                 return _context.SaveChanges();
            }
        }

        public int Remove(Employee employee)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                _context.Employees.Remove(employee);
                return _context.SaveChanges();
            }
        }

        public int Update(Employee employee)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                _context.Employees.Update(employee);
                return _context.SaveChanges();
            }
        }
    }
}