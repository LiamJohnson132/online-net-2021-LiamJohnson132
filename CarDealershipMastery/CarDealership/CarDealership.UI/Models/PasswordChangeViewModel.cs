using CarDealership.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class PasswordChangeViewModel : IValidatableObject
    {
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public bool Success { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (!string.IsNullOrEmpty(Password) && !Validation.IsValidPassword(Password))
            {
                errors.Add(new ValidationResult("Enter a valid password with one capital, one lowercase, one number and one special character, as well as at least 8 characters in length."));

                if (Password != PasswordConfirm)
                {
                    errors.Add(new ValidationResult("Password and confirm password must match."));
                }
            }

            return errors;
        }
    }
}