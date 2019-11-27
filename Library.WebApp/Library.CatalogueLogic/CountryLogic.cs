using Library.DalContracts;
using Library.Entities;
using Library.LogicContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic
{
    public class CountryLogic : ICountryLogic
    {
        private readonly ICountryDao countries;

        public CountryLogic(ICountryDao countryDao)
        {
            this.countries = countryDao;
        }

        public bool Add(Country country)
        {
            return countries.Add(country);
        }

        public bool Delete(int id)
        {
            return countries.Delete(id);
        }

        public bool Edit(Country country)
        {
            return countries.Edit(country);
        }

        public ICollection<Country> GetAll()
        {
            return countries.GetAll();
        }

        public Country GetById(int id)
        {
            return countries.GetById(id);
        }
    }
}
