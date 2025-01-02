﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarFeauture
    {
        public int CarFeautureId { get; set; }
       
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int FeatureId { get; set; }
        public Feature Feature { get; set; }

        public bool Available { get; set; } 
    }
}
