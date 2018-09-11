using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class CustMembershipAgeRestriction: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            else if (customer.DateOfBirth.CompareTo(DateTime.MinValue) == 0)
                return new ValidationResult("Date of Birth is required for this membership type.");
            else
                if (DateTime.Today >= customer.DateOfBirth.Date.AddYears(18))
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Customer must be at least 18 years old to sign up for a reoccurring membership.");
        }
    }
}