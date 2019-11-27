using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities
{
    public class Patent : Publication
    {
        public List<Author> Authors { get; set; }
        public int RegistrationNumber { get; set; }
        public string Country { get; set; }
        public DateTime DatePublication { get; set; }
        public DateTime DateApplication { get; set; }
    }
}
