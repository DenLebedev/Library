using Library.Entities;
using Library.LogicContracts.ValidationLogicContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic.ValidationLogic
{
    public class CountryValidationLogic : ICountryValidationLogic
    {
        public List<ValidationResult> Validate(Country country)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (country == null)
            {
                results.Add(new ValidationResult(true, new ArgumentNullException(nameof(country)).Message.ToString()));
            }

            if (string.IsNullOrWhiteSpace(country.Name))
            {
                results.Add(new ValidationResult(true, new ArgumentException("Name").Message.ToString()));
            }

            return results;
        }
    }
}
