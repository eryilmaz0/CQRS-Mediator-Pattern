using System;
using System.Collections.Generic;
using SolidPractice.Business.Abstract;
using SolidPractice.DataAccess.Abstract;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.Business.Concrete
{
    public class AddressManager :  IAddressService
    {

        private readonly IAddressDal _addressDal;

        //DEPENDENCY INJECTION
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }



        public IList<Address> GetAll()
        {
            return _addressDal.GetAll();
        }



        public Address Get(Func<Address, bool> predicate)
        {
            return _addressDal.Get(predicate);
        }



        public int Add(AddAddressDto addressDto)
        {
            var newAddress = new Address(){Country = addressDto.Country, City = addressDto.City, PostCode = addressDto.PostCode};
            return _addressDal.Add(newAddress);
        }



        public int Remove(int addressId)
        {
            var address = _addressDal.Get(x => x.Id == addressId);

            if (address == null)
                return 0;

            var affectedRows = _addressDal.Remove(address);
            return affectedRows;
        }



        public int Update(UpdateAddressDto updateAddressDto)
        {
            var address = _addressDal.Get(x => x.Id == updateAddressDto.Id);

            if (address == null)
                return 0;

            address.Country = updateAddressDto.Country;
            address.City = updateAddressDto.City;
            address.PostCode = updateAddressDto.PostCode;

            var affectedRows = _addressDal.Update(address);
            return affectedRows;
        }
    }
}