using Library.DalContracts;
using Library.Entities;
using Library.LogicContracts;
using Library.LogicContracts.ValidationLogicContracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic
{
    public class CountryLogic : ICountryLogic
    {
        private readonly ICountryDao countries;
        private readonly ICountryValidationLogic validation;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public CountryLogic(ICountryDao countryDao, ICountryValidationLogic countryValidation)
        {
            this.countries = countryDao;
            this.validation = countryValidation;
        }

        public bool Add(Country country)
        {
            if (validation.Validate(country).Count > 0)
            {
                foreach (var res in validation.Validate(country))
                {
                    if (res.IsValidate)
                    {
                        logger.Error(res.ValidationMessage.ToString());
                    }
                }
            }
            return countries.Add(country);
        }

        public bool Delete(int id)
        {
            return countries.Delete(id);
        }

        public bool Edit(Country country)
        {
            if (validation.Validate(country).Count > 0)
            {
                foreach (var res in validation.Validate(country))
                {
                    if (res.IsValidate)
                    {
                        logger.Error(res.ValidationMessage.ToString());
                    }
                }
            }
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
