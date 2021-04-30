using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookstoreModelLayer
{
    public class CustomerResponse
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Pincode { get; set; }
        public string CustomerAddressType { get; set; }

        [Required]
        public string FullAddress { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        [ForeignKey("CustomerRegistration")]
        public long UserId { get; set; }
    }
}
