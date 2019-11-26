using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities
{
    public class Newspaper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Publishing { get; set; }
        public int Number { get; set; }
        public DateTime YearPublication { get; set; }
        public DateTime DatePublication { get; set; }
        public int PageCount { get; set; }
        public string ISSN { get; set; }
        public string Notes { get; set; }
        public bool MarkDelete { get; set; }
    }
}
