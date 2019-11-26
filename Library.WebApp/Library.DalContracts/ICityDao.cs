using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DalContracts
{
    public interface ICityDao
    {
        bool Add(City city);

        bool Delete(int id);

        bool Edit(City city);

        ICollection<City> GetAll();

        City GetById(int id);
    }
}
