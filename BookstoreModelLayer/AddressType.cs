using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookstoreModelLayer
{
    public class AddressType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressTypeId { get; set; }

        [Required]
        public string CustomerAddressType { get; set; }
    }
}
