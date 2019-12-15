using Library.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApp.Models.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50 characters")]
        [RegularExpression(@"^([a-zA-ZА-Яа-яё])+$", ErrorMessage = "Name can contain only letters")]
        public string Name { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
        public int RoleId { get; set; }

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