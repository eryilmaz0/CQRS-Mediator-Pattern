using System;
using System.Collections;
using System.Collections.Generic;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.Business.Abstract
{
    //ICUSTOMERSERVİCE'İ İMPLEMENTE EDEN SINIF, I PERSONSERVİCE'İDE ETMEK ZORUNDA
    //IPERSONSERVİCE, ICUSTOMERSERVICE'İN REFERANSINI TUTABİLİR
    public interface ICustomerService : IPersonService
    {
        //ICUSTOMERSERVİCE'E ÖZGÜ SERVİSLER
        IList<Customer> GetAll();
        Customer Get(Func<Customer, bool> predicate);
        int Add(AddCustomerDto addCustomerDto);
        int Remove(int customerId);
        int Update(UpdateCustomerDto updateCustomerDto);
    }
}