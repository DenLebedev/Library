using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.LogicContracts
{
    public interface IUserValidationLogic
    {
        List<ValidationResult> Validate(User user);
    }
}
