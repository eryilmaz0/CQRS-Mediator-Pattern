using System;
using System.Collections.Generic;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.Business.Abstract
{
    //IEMPLOYEESERVİCE'İ İMPLEMENTE EDEN SINIF, I PERSONSERVİCE'İDE ETMEK ZORUNDA
    //IPERSONSERVİCE, IEMPLOYEESERVİCE'İN REFERANSINI TUTABİLİR
    public interface IEmployeeService : IPersonService
    {
        //ICUSTOMERSERVİCE'E ÖZGÜ SERVİSLER
        IList<Employee> GetAll();
        Employee Get(Func<Employee, bool> predicate);
        int Add(AddEmployeeDto addEmployeeDto);
        int Remove(int employeeId);
        int Update(UpdateEmployeeDto updateEmployeeDto);
    }
}