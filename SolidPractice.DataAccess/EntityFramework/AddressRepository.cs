using System;
using System.Collections.Generic;
using System.Linq;
using SolidPractice.DataAccess.Abstract;
using SolidPractices.Entities;
using SolidPractices.Entities.Entities;

namespace SolidPractice.DataAccess.EntityFramework
{
    public class AddressRepository : IAddressDal
    {


        public IList<Address> GetAll()
        {
            using (var _context = new SolidPracticeDbContext())
            {
                return _context.Addresses.ToList();
            }
        }



        public Address Get(Func<Address, bool> predicate)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                return _context.Addresses.FirstOrDefault(predicate);
            }
        }



        public int Add(Address address)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                 _context.Addresses.Add(address);
                 return _context.SaveChanges();
            }
        }



        public int Remove(Address address)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                _context.Addresses.Remove(address);
                return _context.SaveChanges();
            }
        }



        public int Update(Address address)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                _context.Addresses.Update(address);
                return _context.SaveChanges();
            }
        }


    }
}