using System;
using System.Collections.Generic;
using System.Linq;
using SolidPractice.DataAccess.Abstract;
using SolidPractices.Entities;
using SolidPractices.Entities.Entities;

namespace SolidPractice.DataAccess.EntityFramework
{
    public class CustomerRepository : ICustomerDal
    {

        public IList<Customer> GetAll()
        {
            using (var _context = new SolidPracticeDbContext())
            {
                return _context.Customers.ToList();
            }
        }

        public Customer Get(Func<Customer, bool> predicate)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                return _context.Customers.FirstOrDefault(predicate);
            }
        }

        public int Add(Customer customer)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                _context.Customers.Add(customer);
                return _context.SaveChanges();
            }
        }

        public int Remove(Customer customer)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                _context.Customers.Remove(customer);
                return _context.SaveChanges();
            }
        }

        public int Update(Customer customer)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                _context.Customers.Update(customer);
                return _context.SaveChanges();
            }
        }
    }
}