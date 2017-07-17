using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.CustomValdiations
{
    public class Min18ToAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unkown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (!customer.Birthdate.HasValue)
                return new ValidationResult("Customer's Birthdate is required");

            return DateTime.Now.Year - customer.Birthdate.Value.Year < 18 ? new ValidationResult("Customer age should be 18 or more to go on membership") : ValidationResult.Success;
        }
    }
}