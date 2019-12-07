using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApp.Models.ViewModels
{
    public class CreateBookViewModel
    {
        public string Name { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
        public int AuthorId { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        public int CityId { get; set; }
        public IEnumerable<SelectListItem> Publishings { get; set; }
        public int PublishingId { get; set; }
        public int YearPublication { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public string Notes { get; set; }

        internal IEnumerable<SelectListItem> SetCities(List<City> cities)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            for (int i = 0; i < cities.Count; i++)
            {
                items.Add(new SelectListItem{
                    Text = cities[i].Name.ToString(),
                    Value = cities[i].Id.ToString()
                }); 
            }

            return items;
        }
        internal IEnumerable<SelectListItem> SetAuthors(List<Author> authors)
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

            return items;
        }

        internal IEnumerable<SelectListItem> SetPublishings(List<Publishing> publishings)
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

            return items;
        }
    }
}
