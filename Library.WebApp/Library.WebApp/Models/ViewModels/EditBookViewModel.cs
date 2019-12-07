using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebApp.Models.ViewModels
{
    public class EditBookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Publishing> Publishings { get; set; }
        public int YearPublication { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public string Notes { get; set; }
    }
}