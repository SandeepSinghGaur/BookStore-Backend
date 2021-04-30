using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookstoreModelLayer
{
   public class WishList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishId { get; set; }

        [Required]
        [ForeignKey("UserRegistration")]
        public long UserId { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }
    }
}
