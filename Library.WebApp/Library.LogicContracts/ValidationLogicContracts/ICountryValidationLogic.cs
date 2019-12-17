using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.LogicContracts.ValidationLogicContracts
{
    public interface ICountryValidationLogic
    {
        List<ValidationResult> Validate(Country country);
    }
}
