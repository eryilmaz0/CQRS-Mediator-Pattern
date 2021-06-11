using System;
using System.Collections.Generic;
using SolidPractices.Entities.Entities;

namespace SolidPractice.DataAccess.Abstract
{
    public interface ISupplierDal
    {
        IList<Supplier> GetAll();
        Supplier Get(Func<Supplier, bool> predicate);
        int Add(Supplier supplier);
        int Remove(Supplier supplier);
        int Update(Supplier supplier);
    }
}