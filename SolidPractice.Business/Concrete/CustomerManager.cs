using System;
using System.Collections.Generic;
using System.Diagnostics;
using SolidPractice.Business.Abstract;
using SolidPractice.Business.Extensions;
using SolidPractice.DataAccess.Abstract;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.Business.Concrete
{
    public class CustomerManager : PersonManager, ICustomerService
    {

        private readonly ICustomerDal _customerDal;
        private readonly IAddressDal _addressDal;


        //DEPENDENCY INJECTION
        public CustomerManager(ICustomerDal customerDal, IAddressDal addressDal)
        {
            _customerDal = customerDal;
            _addressDal = addressDal;
        }



        public IList<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }



        public Customer Get(Func<Customer, bool> predicate)
        {
            return _customerDal.Get(predicate);
        }



        public int Add(AddCustomerDto addCustomerDto)
        {

            var findAddress = _addressDal.Get(x => x.Id == addCustomerDto.AddressId);

            if (findAddress == null)
                return 0;


            var newCustomer = new Customer()
            {
                Name = addCustomerDto.Name,
                LastName = addCustomerDto.LastName,
                Gender = addCustomerDto.Gender,
                AddressId = findAddress.Id,
                CustomerType = addCustomerDto.CustomerType,
            };

            return _customerDal.Add(newCustomer);
        }



        public int Remove(int customerId)
        {
            var findCustomer = _customerDal.Get(x => x.Id == customerId);

            if (findCustomer == null)
            {
                //SİLİNMEK İSTENEN MÜŞTERİ MEVCUT DEĞİL
                return 0;
            }

            return _customerDal.Remove(findCustomer);
        }



        public int Update(UpdateCustomerDto updateCustomerDto)
        {
            var customer = _customerDal.Get(x => x.Id == updateCustomerDto.Id);

            if (customer == null)
                return 0;

            var findAddress = _addressDal.Get(x => x.Id == updateCustomerDto.AddressId);

            if (findAddress == null)
                return 0;

            customer.Name = updateCustomerDto.Name;
            customer.LastName = updateCustomerDto.LastName;
            customer.AddressId = updateCustomerDto.AddressId;
            customer.CustomerType = updateCustomerDto.CustomerType;
            var affectedRows = _customerDal.Update(customer);

            return affectedRows;
        }
    }
}