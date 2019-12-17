using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.LogicContracts.ValidationLogicContracts
{
    public interface IAuthorValidationLogic
    {
        List<ValidationResult> Validate(Author author);
    }
}
