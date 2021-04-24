using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookstoreModelLayer
{
   public class CustomerRegistration
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string role { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public String phone { get; set; }
    }
}
