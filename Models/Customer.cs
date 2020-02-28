using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace customer_api.Models
{
    [Table("customer")]
    public class Customer
    {
        [Column("customer_id")]
        public long CustomerId { get; set; }

        [Required]
        [Column("firstname")]
        public String Firstname { get; set; }

        [Column("lastname")]
        public String Lastname { get; set; }

        [Required]
        [Column("email_address")]
        public String EmailAddress { get; set; }
    }
}