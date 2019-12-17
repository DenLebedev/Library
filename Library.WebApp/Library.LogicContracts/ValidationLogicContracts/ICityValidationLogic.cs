using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.LogicContracts.ValidationLogicContracts
{
    public interface ICityValidationLogic
    {
        List<ValidationResult> Validate(City city);
    }
}
