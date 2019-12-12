using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.WebApp.Models.ViewModels
{
    public class EditPublishingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(300, ErrorMessage = "Publishing name length can't be more than 300 characters")]
        public string Name { get; set; }
    }
}