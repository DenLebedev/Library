using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DalContracts
{
    public interface ICountryDao
    {
        bool Add(Country country);

        bool Delete(int id);

        bool Edit(Country country);

        ICollection<Country> GetAll();

        Country GetById(int id);
    }
}
