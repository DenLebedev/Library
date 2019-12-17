using Library.Entities;
using Library.LogicContracts.ValidationLogicContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic.ValidationLogic
{
    public class UserValidationLogic : IUserValidationLogic
    {
        public List<ValidationResult> Validate(User user)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (user == null)
            {
                results.Add(new ValidationResult(true, new ArgumentNullException(nameof(user)).Message.ToString()));
            }

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                results.Add(new ValidationResult(true, new ArgumentException("Username").Message.ToString()));
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                results.Add(new ValidationResult(true, new ArgumentException("Password").Message.ToString()));
            }

            return results;
        }
    }
}
