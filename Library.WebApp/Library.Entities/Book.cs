using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; }
        public string City { get; set; }
        public string Publishing { get; set; }
        public DateTime YearPublication { get; set; }
        public int PageCount { get; set; }
        public string ISBN { get; set; }
        public string Notes { get; set; }
        public bool MarkDelete { get; set; }
        
    }
}
