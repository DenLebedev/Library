using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities
{
    public class ValidationResult
    {
        public bool IsValidate { get; set; }
        public string ValidationMessage { get; set; }

        public ValidationResult(bool valid, string message) 
        {
            this.IsValidate = valid;
            this.ValidationMessage = message;
        }

        public ValidationResult()
        {
            
        }
    }
}
