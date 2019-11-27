using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities
{
    public class Book : Publication
    {
        public List<Author> Authors { get; set; }
        public string City { get; set; }
        public string Publishing { get; set; }
        public DateTime YearPublication { get; set; }
        public string ISBN { get; set; }        
    }
}
