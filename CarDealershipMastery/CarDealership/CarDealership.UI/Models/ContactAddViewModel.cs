using CarDealership.Data;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class ContactAddViewModel : IValidatableObject
    {
        public Contact Contact { get; set; }
        public string VIN { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Contact.Name))
            {
                errors.Add(new ValidationResult("Please specify your name."));
            }

            if (string.IsNullOrEmpty(Contact.Email) && string.IsNullOrEmpty(Contact.Phone))
            {
                errors.Add(new ValidationResult("Please specify your phone number and/or your email address."));
            }

            if (!string.IsNullOrEmpty(Contact.Email))
            {
                if (!Validation.IsValidEmail(Contact.Email))
                {
                    errors.Add(new ValidationResult("Please enter a valid email address."));
                }
            }

            if (!string.IsNullOrEmpty(Contact.Phone))
            {
                if (Contact.Phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace(" ", "").Length != 10 && 
                    Contact.Phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace(" ", "").All(c => c >= 0 && c <= 9))
                {
                    errors.Add(new ValidationResult("Enter a valid phone number with 10 digits."));
                }
            }

            if (string.IsNullOrEmpty(Contact.Message))
            {
                errors.Add(new ValidationResult("Please enter the message you want to send us."));
            }

            return errors;
        }
    }
}