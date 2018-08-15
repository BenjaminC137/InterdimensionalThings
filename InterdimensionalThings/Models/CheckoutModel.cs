using System;
using System.ComponentModel.DataAnnotations;

namespace InterdimensionalThings.Models
{
    public class CheckoutModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]

        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        [Required]
        public string Nonce { get; set; }

        //public CheckoutModel()
        //{
        //}
    }
}
