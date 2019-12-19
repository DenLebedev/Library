using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Library.WebApp.Models.ViewModels
{
    public class LoginViewModel : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(50, ErrorMessage = "Username length can't be more than 50 characters")]
        [RegularExpression(@"^([a-zA-ZА-Яа-яё])+$", ErrorMessage = "Username can contain only letters")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This is a required field")]
        [StringLength(50, ErrorMessage = "Password length can't be more than 50 characters")]
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                yield return new ValidationResult("Username cannot be empty", new[] { nameof(Username) });
            }

            if (Username.Length > 50)
            {
                yield return new ValidationResult("Username length can't be more than 50 characters", new[] { nameof(Username) });
            }

            var regexUsername = new Regex(@"^([a-zA-ZА-Яа-яё])+$");
            MatchCollection matches = regexUsername.Matches(Username);
            if (matches.Count == 0)
            {
                yield return new ValidationResult("Username can contain only letters", new[] { nameof(Username) });
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                yield return new ValidationResult("Password cannot be empty", new[] { nameof(Password) });
            }

            if (Password.Length > 50)
            {
                yield return new ValidationResult("Password length can't be more than 50 characters", new[] { nameof(Password) });
            }
        }
    }
}