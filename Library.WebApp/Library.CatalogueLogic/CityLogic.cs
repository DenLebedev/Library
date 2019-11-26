using Library.DalContracts;
using Library.Entities;
using Library.LogicContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic
{
    public class CityLogic : ICityLogic
    {
        private readonly ICityDao cities;

        public CityLogic(ICityDao cityDao)
        {
            this.cities = cityDao;
        }

        public bool Add(City city)
        {
            return cities.Add(city);
        }

        public bool Delete(int id)
        {
            return cities.Delete(id);
        }

        public bool Edit(City city)
        {
            return cities.Edit(city);
        }

        public ICollection<City> GetAll()
        {
            return cities.GetAll();
        }

        public City GetById(int id)
        {
            return cities.GetById(id);
        }
    }
}
