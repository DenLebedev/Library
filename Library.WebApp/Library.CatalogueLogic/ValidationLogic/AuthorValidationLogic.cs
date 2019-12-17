using Library.Entities;
using Library.LogicContracts.ValidationLogicContracts;
using System;
using System.Collections.Generic;

namespace Library.CatalogueLogic.ValidationLogic
{
    public class AuthorValidationLogic : IAuthorValidationLogic
    {
        public List<ValidationResult> Validate(Author author)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (author == null)
            {                
                results.Add(new ValidationResult(true, new ArgumentNullException(nameof(author)).Message.ToString()));
            }

            if (string.IsNullOrWhiteSpace(author.Name))
            {
                results.Add(new ValidationResult(true, new ArgumentException("Name").Message.ToString()));
            }

            if (string.IsNullOrWhiteSpace(author.Surname))
            {
                results.Add(new ValidationResult(true, new ArgumentException("Surname").Message.ToString()));
            }

            return results;
        }
    }
}
