using System;
using System.Collections.Generic;
using SolidPractices.Entities.Entities;

namespace SolidPractice.DataAccess.Abstract
{
    public interface IEmployeeDal
    {
        IList<Employee> GetAll();
        Employee Get(Func<Employee, bool> predicate);
        int Add(Employee employee);
        int Remove(Employee employee);
        int Update(Employee employee);
    }
}