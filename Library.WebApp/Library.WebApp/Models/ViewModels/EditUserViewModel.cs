using Library.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApp.Models.ViewModels
{
    public class EditUserViewModel : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50 characters")]
        [RegularExpression(@"^([a-zA-ZА-Яа-яё])+$", ErrorMessage = "Name can contain only letters")]
        public string Name { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
        public int RoleId { get; set; }

        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("The user Name cannot be empty", new[] { nameof(Name) });
            }

            if (Name.Length > 50)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Username length can't be more than 50 characters", new[] { nameof(Name) });
            }

            var regexName = new Regex(@"^([a-zA-ZА-Яа-яё])+$");
            MatchCollection matches = regexName.Matches(Name);
            if (matches.Count == 0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Username can contain only letters", new[] { nameof(Name) });
            }
        }

        internal void SetRoles(List<UserRole> roles)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            for (int i = 0; i < roles.Count; i++)
            {
                items.Add(new SelectListItem
                {
                    Text = roles[i].Name.ToString(),
                    Value = roles[i].Id.ToString()
                });
            }
            this.Roles = items;
        }

    }
}