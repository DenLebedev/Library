using System;
using System.Collections.Generic;

namespace Library.Entities
{
    public class CatalogueCart
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; }
        public DateTime YearPublication { get; set; }
        public DateTime DatePublication { get; set; }
        public DateTime DateApplication { get; set; }
        public int RegistrationNumber { get; set; }
        public string ISBN { get; set; }
        public string ISSN { get; set; }
        public int EditionNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Publishing { get; set; }
        public int PageCount { get; set; }
        public string Notes { get; set; }
    }
}
