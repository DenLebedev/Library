using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities
{
    public class Book : Publication
    {
        public Author Author { get; set; }
        public City City { get; set; }
        public Publishing Publishing { get; set; }
        public int YearPublication { get; set; } 
        public string ISBN { get; set; }

        public Book()
        {
            this.Author = new Author();
            this.City = new City();
            this.Publishing = new Publishing();
        }
    }
}
