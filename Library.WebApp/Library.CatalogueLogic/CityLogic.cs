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
    public class CityLogic : ICityLogic
    {
        private readonly ICityDao cities;
        private readonly ICityValidationLogic validation;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public CityLogic(ICityDao cityDao, ICityValidationLogic cityValidation)
        {
            this.cities = cityDao;
            this.validation = cityValidation;
        }

        public bool Add(City city)
        {
            if (validation.Validate(city).Count > 0)
            {
                foreach (var res in validation.Validate(city))
                {
                    if (res.IsValidate)
                    {
                        logger.Error(res.ValidationMessage.ToString());
                    }
                }
            }
            return cities.Add(city);
        }

        public bool Delete(int id)
        {
            return cities.Delete(id);
        }

        public bool Edit(City city)
        {
            if (validation.Validate(city).Count > 0)
            {
                foreach (var res in validation.Validate(city))
                {
                    if (res.IsValidate)
                    {
                        logger.Error(res.ValidationMessage.ToString());
                    }
                }
            }
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
