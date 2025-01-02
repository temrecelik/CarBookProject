using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Car
    {
        public int CarId { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string model { get; set; }   
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; } 
        public byte Seat { get; set; }   
        public string Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }

        public List<CarFeauture> CarFeautures { get; set; }

        public List<CarDescription> CarDescriptions { get; set; }

        public List<CarPricing> carPricings { get; set; }
    }
}
