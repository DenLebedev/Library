using Library.Entities;
using Library.LogicContracts.ValidationLogicContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic.ValidationLogic
{
    public class NewspaperNameValidationLogic : INewspaperNameValidationLogic
    {
        public List<ValidationResult> Validate(NewspaperName newspaperName)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (newspaperName == null)
            {
                results.Add(new ValidationResult(true, new ArgumentNullException(nameof(newspaperName)).Message.ToString()));
            }

            if (string.IsNullOrWhiteSpace(newspaperName.Name))
            {
                results.Add(new ValidationResult(true, new ArgumentException("Name").Message.ToString()));
            }

            return results;
        }
    }
}
