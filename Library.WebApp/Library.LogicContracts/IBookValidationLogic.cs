using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.LogicContracts
{
    public interface IBookValidationLogic
    {
        List<ValidationResult> Validate(Book book);
    }
}
