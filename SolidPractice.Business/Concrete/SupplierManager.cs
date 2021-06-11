using System;
using System.Collections.Generic;
using SolidPractice.Business.Abstract;
using SolidPractice.DataAccess.Abstract;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.Business.Concrete
{
    public class SupplierManager : PersonManager, ISupplierService
    {

        private readonly ISupplierDal _supplierDal;
        private readonly IAddressDal _addressDal;


        //DEPENDENCY INJECTION
        public SupplierManager(ISupplierDal supplierDal, IAddressDal addressDal)
        {
            _supplierDal = supplierDal;
            _addressDal = addressDal;
        }


        public IList<Supplier> GetAll()
        {
            return _supplierDal.GetAll();
        }





        public Supplier Get(Func<Supplier, bool> predicate)
        {
            return _supplierDal.Get(predicate);
        }





        public int Add(AddSupplierDto addSupplierDto)
        {
            var findAddress = _addressDal.Get(x => x.Id == addSupplierDto.AddressId);

            if (findAddress == null)
                return 0;


            var newSupplier = new Supplier()
            {
                Name = addSupplierDto.Name,
                LastName = addSupplierDto.LastName,
                Gender = addSupplierDto.Gender,
                AddressId = findAddress.Id,
                CompanyName = addSupplierDto.CompanyName,
                Fax = addSupplierDto.Fax

            };


            return _supplierDal.Add(newSupplier);
        }




        public int Remove(int employeeId)
        {
            var findEmployee = _supplierDal.Get(x => x.Id == employeeId);

            if (findEmployee == null)
            {
                //SİLİNMEK İSTENEN MÜŞTERİ MEVCUT DEĞİL
                return 0;
            }

            return _supplierDal.Remove(findEmployee);
        }





        public int Update(UpdateSupplierDto updateSupplierDto)
        {
            var employee = _supplierDal.Get(x => x.Id == updateSupplierDto.Id);

            if (employee == null)
                return 0;

            var findAddress = _addressDal.Get(x => x.Id == updateSupplierDto.AddressId);

            if (findAddress == null)
                return 0;

            employee.Name = updateSupplierDto.Name;
            employee.LastName = updateSupplierDto.LastName;
            employee.AddressId = updateSupplierDto.AddressId;
            employee.CompanyName = updateSupplierDto.CompanyName;
            employee.Fax = updateSupplierDto.Fax;
            var affectedRows = _supplierDal.Update(employee);

            return affectedRows;
        }
    }
}