using System;
using System.Collections.Generic;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.Business.Abstract
{
    //IADDRESSSERVİCE'İ İMPLEMENTE EDEN SINIF, I PERSONSERVİCE'İDE ETMEK ZORUNDA
    //IPERSONSERVİCE, IADDRESSSERVİCE'İN REFERANSINI TUTABİLİR
    public interface IAddressService
    {
        //IADDRESSSERVİCE'E ÖZGÜ SERVİSLER
        IList<Address> GetAll();
        Address Get(Func<Address, bool> predicate);
        int Add(AddAddressDto addressDto);
        int Remove(int addressId);
        int Update(UpdateAddressDto updateAddressDto);
    }
}