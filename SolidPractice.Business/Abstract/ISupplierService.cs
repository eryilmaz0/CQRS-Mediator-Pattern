using System;
using System.Collections.Generic;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.Business.Abstract
{
    //ISUPPLIERSERVİCE'İ İMPLEMENTE EDEN SINIF, I PERSONSERVİCE'İDE ETMEK ZORUNDA
    //IPERSONSERVİCE, ISUPPLIERSERVICE'İN REFERANSINI TUTABİLİR
    public interface ISupplierService : IPersonService
    {
        //ISUPPLIERSERVİCE'E ÖZGÜ SERVİSLER
        IList<Supplier> GetAll();
        Supplier Get(Func<Supplier, bool> predicate);
        int Add(AddSupplierDto addSupplierDto);
        int Remove(int employeeId);
        int Update(UpdateSupplierDto updateSupplierDto);
    }
}