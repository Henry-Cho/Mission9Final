using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Mission9Final.Models
{
    public class Shopper
    {
        [Key]
        [BindNever]
        public int ShopperId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a first name:")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Please enter a last name:")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Please the first address line:")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please the city name:")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please the state name:")]
        public string State { get; set; }
        //[Required(ErrorMessage = "Please the zip code:")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please the country:")]
        public string Country { get; set; }
    }
}
