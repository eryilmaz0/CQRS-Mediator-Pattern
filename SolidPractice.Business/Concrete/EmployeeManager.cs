using System;
using System.Collections.Generic;
using SolidPractice.Business.Abstract;
using SolidPractice.DataAccess.Abstract;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.Business.Concrete
{
    public class EmployeeManager : PersonManager, IEmployeeService
    {

        private readonly IEmployeeDal _employeeDal;
        private readonly IAddressDal _addressDal;



        //DEPENDENCY INJECTION
        public EmployeeManager(IEmployeeDal employeeDal, IAddressDal addressDal)
        {
            _employeeDal = employeeDal;
            _addressDal = addressDal;
        }



        public IList<Employee> GetAll()
        {
            return _employeeDal.GetAll();
        }




        public Employee Get(Func<Employee, bool> predicate)
        {
            return _employeeDal.Get(predicate);
        }




        public int Add(AddEmployeeDto addEmployeeDto)
        {
            var findAddress = _addressDal.Get(x => x.Id == addEmployeeDto.AddressId);

            if (findAddress == null)
                return 0;


            var newEmployee = new Employee()
            {
                Name = addEmployeeDto.Name,
                LastName = addEmployeeDto.LastName,
                Gender = addEmployeeDto.Gender,
                AddressId = findAddress.Id,
                DepartmentCode = addEmployeeDto.DepartmentCode,
                DepartmentName = addEmployeeDto.DepartmentName,
                ReportsTo = addEmployeeDto.ReportsTo

            };

            return _employeeDal.Add(newEmployee);
        }




        public int Remove(int employeeId)
        {
            var findEmployee = _employeeDal.Get(x => x.Id == employeeId);

            if (findEmployee == null)
            {
                //SİLİNMEK İSTENEN MÜŞTERİ MEVCUT DEĞİL
                return 0;
            }

            return _employeeDal.Remove(findEmployee);
        }





        public int Update(UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = _employeeDal.Get(x => x.Id == updateEmployeeDto.Id);

            if (employee == null)
                return 0;

            var findAddress = _addressDal.Get(x => x.Id == updateEmployeeDto.AddressId);

            if (findAddress == null)
                return 0;

            employee.Name = updateEmployeeDto.Name;
            employee.LastName = updateEmployeeDto.LastName;
            employee.AddressId = updateEmployeeDto.AddressId;
            employee.DepartmentCode = updateEmployeeDto.DepartmentCode;
            employee.DepartmentName = updateEmployeeDto.DepartmentName;
            employee.ReportsTo = updateEmployeeDto.ReportsTo;
            var affectedRows = _employeeDal.Update(employee);

            return affectedRows;
        }
    }
}