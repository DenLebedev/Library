using Library.Entities;
using Library.LogicContracts;
using Library.LogicContracts.ValidationLogicContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic.ValidationLogic
{
    public class CityValidationLogic : ICityValidationLogic
    {
        public List<ValidationResult> Validate(City city)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (city == null)
            {
                results.Add(new ValidationResult(true, new ArgumentNullException(nameof(city)).Message.ToString()));
            }

            if (string.IsNullOrWhiteSpace(city.Name))
            {
                results.Add(new ValidationResult(true, new ArgumentException("Name").Message.ToString()));
            }

            return results;
        }
    }
}
