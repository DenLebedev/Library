using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities
{
    public class Patent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; }
        public int RegistrationNumber { get; set; }
        public string Country { get; set; }
        public DateTime DatePublication { get; set; }
        public DateTime DateApplication { get; set; }
        public int PageCount { get; set; }
        public string Notes { get; set; }
        public bool MarkDelelete { get; set; }
    }
}
