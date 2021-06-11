using System;
using System.Collections.Generic;
using SolidPractices.Entities.Entities;

namespace SolidPractice.DataAccess.Abstract
{
    public interface ICustomerDal
    {
        IList<Customer> GetAll();
        Customer Get(Func<Customer, bool> predicate);
        int Add(Customer customer);
        int Remove(Customer customer);
        int Update(Customer customer);
    }
}