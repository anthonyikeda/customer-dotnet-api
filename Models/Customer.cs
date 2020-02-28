using System;
using System.ComponentModel.DataAnnotations;

namespace customer_api.Models
{
    public class Customer
    {
        public long CustomerId { get; set; }

        [Required]
        public String Firstname { get; set; }

        public String Lastname { get; set; }

        [Required]
        public String EmailAddress { get; set; }
    }
}