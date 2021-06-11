using System;
using System.Collections.Generic;
using System.Linq;
using SolidPractice.DataAccess.Abstract;
using SolidPractices.Entities;
using SolidPractices.Entities.Entities;

namespace SolidPractice.DataAccess.EntityFramework
{
    public class SupplierRepository : ISupplierDal
    {


        public IList<Supplier> GetAll()
        {
            using (var _context = new SolidPracticeDbContext())
            {
                return _context.Suppliers.ToList();
            }
        }

        public Supplier Get(Func<Supplier, bool> predicate)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                return _context.Suppliers.FirstOrDefault(predicate);
            }
        }

        public int Add(Supplier supplier)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                 _context.Suppliers.Add(supplier);
                 return _context.SaveChanges();
            }
        }

        public int Remove(Supplier supplier)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                _context.Suppliers.Remove(supplier);
                return _context.SaveChanges();
            }
        }

        public int Update(Supplier supplier)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                _context.Suppliers.Update(supplier);
                return _context.SaveChanges();
            }
        }
    }
}