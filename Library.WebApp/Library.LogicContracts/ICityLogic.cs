using System;
using System.Collections.Generic;
using System.Text;
using Library.Entities;

namespace Library.LogicContracts
{
    public interface ICityLogic
    {
        bool Add(City city);

        bool Delete(int id);

        bool Edit(City city);

        ICollection<City> GetAll();

        City GetById(int id);
    }
}
