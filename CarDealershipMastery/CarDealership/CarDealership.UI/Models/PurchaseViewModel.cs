using CarDealership.Data;
using CarDealership.Models;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class PurchaseViewModel : IValidatableObject
    {
        public Car Car { get; set; }
        public List<PurchaseType> PurchaseTypes { get; set; }
        public List<State> States { get; set; }
        public Order Order { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Order.Name))
            {
                errors.Add(new ValidationResult("Please specify the name for the order."));
            }

            if (!string.IsNullOrEmpty(Order.Name))
            {
                if (Order.Name.Length > 50)
                {
                    errors.Add(new ValidationResult("The maximum length of a name is 50 characters."));
                }
            }
            
            if (string.IsNullOrEmpty(Order.Phone) && string.IsNullOrEmpty(Order.Email))
            {
                errors.Add(new ValidationResult("Please specify a phone number or an email for the order."));
            }

            if (!string.IsNullOrEmpty(Order.Phone))
            {
                if (Order.Phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace(" ", "").Length != 10 &&
                    Order.Phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace(" ", "").All(c => c >= 0 && c <= 9))
                {
                    errors.Add(new ValidationResult("Enter a valid phone number with 10 digits."));
                }
            }

            if (!string.IsNullOrEmpty(Order.Email))
            {
                if (!Validation.IsValidEmail(Order.Email))
                {
                    errors.Add(new ValidationResult("Please specify a valid email for the order."));
                }
            }

            if (!string.IsNullOrEmpty(Order.Email))
            {
                if (Order.Email.Length > 50)
                {
                    errors.Add(new ValidationResult("The maximum length of an email is 50 characters."));
                }
            }

            if (string.IsNullOrEmpty(Order.StreetOne))
            {
                errors.Add(new ValidationResult("Please specify the street address for the order."));
            }

            if (!string.IsNullOrEmpty(Order.StreetOne))
            {
                if (Order.StreetOne.Length > 50)
                {
                    errors.Add(new ValidationResult("The maximum length of a street address is 50 characters."));
                }
            }

            if (!string.IsNullOrEmpty(Order.StreetTwo))
            {
                if (Order.StreetTwo.Length > 50)
                {
                    errors.Add(new ValidationResult("The maximum length of a street address is 50 characters."));
                }
            }

            if (string.IsNullOrEmpty(Order.City))
            {
                errors.Add(new ValidationResult("Please specify the city for the order."));
            }

            if (!string.IsNullOrEmpty(Order.City))
            {
                if (Order.City.Length > 50)
                {
                    errors.Add(new ValidationResult("The maximum length of a city is 50 characters."));
                }
            }

            if (string.IsNullOrEmpty(Order.Zipcode))
            {
                errors.Add(new ValidationResult("Please specify the zipcode for the order."));
            }

            if (!string.IsNullOrEmpty(Order.Zipcode))
            {
                if (Order.Zipcode.Length != 5)
                {
                    errors.Add(new ValidationResult("The zipcode should have exactly 5 characters."));
                }
            }

            if (Order.PurchasePrice > 999999.99M)
            {
                errors.Add(new ValidationResult("The maximum purchase price is $999999.99."));
            }

            if (Order.PurchasePrice > Car.MSRP)
            {
                errors.Add(new ValidationResult("The purchase price cannot exceed the MSRP."));
            }

            if (Order.PurchasePrice < (Car.Price * 0.95M))
            {
                errors.Add(new ValidationResult("Purchase price cannot be less than 95% of sale price."));
            }

            if (Order.PurchasePrice == 0M)
            {
                errors.Add(new ValidationResult("Please enter a purchase price."));
            }

            return errors;
        }
    }
}