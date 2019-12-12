using Library.Entities;
using Library.LogicContracts;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApp.Models.ViewModels
{
    public class EditBookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(300, ErrorMessage = "Name length can't be more than 300 characters")]
        public string Name { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }
        public int AuthorId { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> Publishings { get; set; }
        public int PublishingId { get; set; }

        [Required(ErrorMessage = "This is a required field")] 
        [Range(1400, 9999, ErrorMessage = "The Year of publication is incorrect")]
        public int YearPublication { get; set; }
        
        [RegularExpression(@"\b(?:ISBN(?:: ?| ))?((?:97[89])?\d{9}[\dx])\b", ErrorMessage = "Incorrect ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "This field can only contain numbers")]
        [Range(1, 9999, ErrorMessage = "The number of pages cannot be less than 1")]
        public int PageCount { get; set; }

        [StringLength(2000, ErrorMessage = "Name length can't be more than 2000 characters")]
        public string Notes { get; set; }

        internal void SetCities(List<City> cities)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            for (int i = 0; i < cities.Count; i++)
            {
                items.Add(new SelectListItem{
                    Text = cities[i].Name.ToString(),
                    Value = cities[i].Id.ToString()
                }); 
            }

            this.Cities = items;
        }
        internal void SetAuthors(List<Author> authors)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            for (int i = 0; i < authors.Count; i++)
            {
                items.Add(new SelectListItem
                {
                    Text = authors[i].Name.ToString() + " " + authors[i].Surname.ToString(),
                    Value = authors[i].Id.ToString()
                });
            }

            this.Authors = items;
        }

        internal void SetPublishings(List<Publishing> publishings)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            for (int i = 0; i < publishings.Count; i++)
            {
                items.Add(new SelectListItem
                {
                    Text = publishings[i].Name.ToString(),
                    Value = publishings[i].Id.ToString()
                });
            }

            this.Publishings = items;
        }
    }
}
