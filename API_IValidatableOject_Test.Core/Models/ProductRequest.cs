using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_IValidatableOject_Test.Core.Models
{
    public class ProductRequest : IValidatableObject
    {
        [Required, MinLength(1, ErrorMessage = "The ID of the product must be at leat an 1 char long"),
                   MaxLength(30, ErrorMessage = "The ID cannot be greater than 30 char long")]
        public string ID { get; set; }
        [MinLength(1, ErrorMessage = "The name of the product cannot be empty")]
        public string Name { get; set; }
        [Required]
        public uint Quantity { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (int.Parse(ID) > 3)
            {
                results.Add(new ValidationResult($"There's no product with the ID: {ID}"));
            }
            if (!string.IsNullOrEmpty(Name) && (!Name.Equals("foo") || !Name.Equals("bar")))
            {
                results.Add(new ValidationResult("The valid names are :foo or bar"));
            }
            if (Quantity < 1)
            {
                results.Add(new ValidationResult("Quantity must be greater than 0"));
            }
            return results;
         }
    }
}
