using Library.Entities;
using Library.LogicContracts.ValidationLogicContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic.ValidationLogic
{
    public class PublishingValidationLogic : IPublishingValidationLogic
    {
        public List<ValidationResult> Validate(Publishing publishing)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (publishing == null)
            {
                results.Add(new ValidationResult(true, new ArgumentNullException(nameof(publishing)).Message.ToString()));
            }

            if (string.IsNullOrWhiteSpace(publishing.Name))
            {
                results.Add(new ValidationResult(true, new ArgumentException("Name").Message.ToString()));
            }

            return results;
        }
    }
}
