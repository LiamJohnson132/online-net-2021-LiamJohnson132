using CarDealership.Data;
using CarDealership.Models.Queries;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CarDealership.UI.Models
{
    public class UserAddViewModel : IValidatableObject
    {
        public List<RoleModel> Roles { get; set; }
        public UserModel UserModel { get; set; }
        public string CurrentRole { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(UserModel.FirstName))
            {
                errors.Add(new ValidationResult("Please specify the first name for the user."));
            }

            if (string.IsNullOrEmpty(UserModel.LastName))
            {
                errors.Add(new ValidationResult("Please specify the last name for the user."));
            }

            if (string.IsNullOrEmpty(UserModel.Email))
            {
                errors.Add(new ValidationResult("Please specify the email for the user."));
            } else if (!Validation.IsValidEmail(UserModel.Email))
            {
                errors.Add(new ValidationResult("Please enter a valid email address."));
            }

            if (string.IsNullOrEmpty(UserModel.Password))
            {
                errors.Add(new ValidationResult("Please specify the password for the user."));
            } else
            {
                if (!Validation.IsValidPassword(UserModel.Password))
                {
                    errors.Add(new ValidationResult("Enter a valid password with one capital, one lowercase, one number and one special character, as well as at least 8 characters in length."));
                }

                if (UserModel.Password != UserModel.PasswordConfirm)
                {
                    errors.Add(new ValidationResult("Password and confirm password must match."));
                }
            }

            return errors;
        }
    }
}