using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.WebApp.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "This is a required field")]
        [StringLength(50, ErrorMessage = "Username length can't be more than 50 characters")]
        [RegularExpression(@"^([a-zA-ZА-Яа-яё])+$", ErrorMessage = "Username can contain only letters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(50, ErrorMessage = "Password length can't be more than 50 characters")]
        public string Password { get; set; }
    }
}