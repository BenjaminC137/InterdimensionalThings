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

        //public CheckoutModel()
        //{
        //}
    }
}