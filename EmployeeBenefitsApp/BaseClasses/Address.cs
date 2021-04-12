using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeBenefitsApp.BaseClasses
{
    public class Address
    {
        [Display(Name = "Address 1")]
        [MaxLength(60, ErrorMessage = "Address 1 cannot be longer than 60 characters")]
        public string AddressLine1 { get; set; }
        
        [Display(Name = "Address 2")]
        [MaxLength(15, ErrorMessage = "Address 2 cannot be longer than 15 characters")]
        public string AddressLine2 { get; set; }

        [MaxLength(30, ErrorMessage = "City cannot be longer than 30 characters")]
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Zip")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code")]
        public string ZipCode { get; set; }
    }
}