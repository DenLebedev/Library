using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities
{
    public class Publication
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int PageCount { get; set; }
        public string Notes { get; set; }
        public bool MarkDelete { get; set; }
    }
}
