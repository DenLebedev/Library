﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities 
{
    public class Newspaper : Publication
    {
        public string City { get; set; }
        public string Publishing { get; set; }
        public int Number { get; set; }
        public DateTime YearPublication { get; set; }
        public DateTime DatePublication { get; set; }
        public string ISSN { get; set; }
    }
}
