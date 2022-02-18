using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string VIN { get; set; }
        public string ImgFileName { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }
        public decimal MSRP { get; set; }
        public string Description { get; set; }
        public bool IsSold { get; set; }
        public bool IsFeatured { get; set; }
        public int ModelId { get; set; }
        public int InteriorId { get; set; }
        public int MakeId { get; set; }
        public int ColorId { get; set; }
        public int TypeId { get; set; }
        public int TransmissionId { get; set; }
        public int BodyStyleId { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string BodyStyle { get; set; }
        public string Interior { get; set; }
        public string Transmission { get; set; }
    }
}
