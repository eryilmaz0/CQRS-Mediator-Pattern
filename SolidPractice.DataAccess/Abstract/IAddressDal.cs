using System;
using System.Collections;
using System.Collections.Generic;
using SolidPractices.Entities.Entities;

namespace SolidPractice.DataAccess.Abstract
{
    public interface IAddressDal
    {
        IList<Address> GetAll();
        Address Get(Func<Address, bool> predicate);
        int Add(Address address);
        int Remove(Address address);
        int Update(Address address);
    }
}