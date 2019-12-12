using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.WebApp.Models.ViewModels
{
    public class CreateAuthorViewModel
    {
        //public int Id { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50 characters")]
        [RegularExpression(@"^([a-zA-ZА-Яа-яё '-])+$", ErrorMessage = "Name can contain only letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(200, ErrorMessage = "Surname length can't be more than 200 characters")]
        [RegularExpression(@"^([a-zA-ZА-Яа-яё '-])+$", ErrorMessage = "Surname can contain only letters")]
        public string Surname { get; set; }
    }
}