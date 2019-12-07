using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebApp.Models.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public City City { get; set; }
        public Publishing Publishing { get; set; }
        public int YearPublication { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public string Notes { get; set; }
        public bool MarkDelete { get; set; }

        public BookViewModel()
        {
            this.Author = new Author();
            this.City = new City();
            this.Publishing = new Publishing();
        }
    }
}