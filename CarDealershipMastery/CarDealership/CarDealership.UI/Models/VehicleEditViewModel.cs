using CarDealership.Models;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class VehicleEditViewModel : IValidatableObject
    {
        public Car Car { get; set; }
        public List<Make> Makes { get; set; }
        public List<VehicleType> Types { get; set; }
        public List<BodyStyle> BodyStyles { get; set; }
        public List<Transmission> Transmissions { get; set; }
        public List<Color> Colors { get; set; }
        public List<Interior> Interiors { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Car.Year > DateTime.Today.Year + 1 || Car.Year < 2000)
            {
                errors.Add(new ValidationResult($"Enter a valid year between 2000 and {DateTime.Today.Year + 1}."));
            }

            if (string.IsNullOrEmpty(Car.VIN))
            {
                errors.Add(new ValidationResult("Enter the car's VIN."));
            }

            if (!string.IsNullOrEmpty(Car.VIN))
            {
                if (Car.VIN.Length != 17)
                {
                    errors.Add(new ValidationResult("Enter a valid VIN."));
                }
            }

            if (Car.Mileage > 1000 && Car.TypeId == 0)
            {
                errors.Add(new ValidationResult("Mileage cannot exceed 1000 if the car is new."));
            }

            if (Car.Mileage < 1000 && Car.TypeId == 1)
            {
                errors.Add(new ValidationResult("Mileage cannot be less than 1000 if the car is used."));
            }

            if (Car.Price > Car.MSRP)
            {
                errors.Add(new ValidationResult("Price cannot exceed the MSRP."));
            }

            if (Car.MSRP == 0)
            {
                errors.Add(new ValidationResult("Enter the car's MSRP."));
            }

            if (Car.Price == 0)
            {
                errors.Add(new ValidationResult("Enter the car's price."));
            }

            if (string.IsNullOrEmpty(Car.Description))
            {
                errors.Add(new ValidationResult("Enter the car's description."));
            }
            else
            {
                if (Car.Description.Length > 500)
                {
                    errors.Add(new ValidationResult("The description can be no more than 500 characters."));
                }
            }

            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var validExtensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };
                var extension = Path.GetExtension(ImageUpload.FileName);

                if (!validExtensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, png, gif, or jpeg."));
                }
            }

            return errors;
        }
    }
}