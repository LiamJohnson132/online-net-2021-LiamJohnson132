using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class ModelsViewModel : IValidatableObject
    {
        public List<Make> Makes { get; set; }
        public List<Model> Models { get; set; }
        public Model NewModel { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(NewModel.Name))
            {
                errors.Add(new ValidationResult("Please specify the name for the model."));
            }

            return errors;
        }
    }
}