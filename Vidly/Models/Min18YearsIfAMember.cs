using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Casting customer validation information to an instance of the Customer object
            var customer = (Customer)validationContext.ObjectInstance;

            // if there is no membership type selected or it is Pay as you go
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            // checking to see if age will be 18
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) ? 
                ValidationResult.Success 
                : new ValidationResult("You must be at least 18 years old to go on a membership");
        }
    }
}