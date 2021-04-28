using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookstoreModelLayer
{
    public class BookCart
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookCartId { get; set; }
        public int BookQuantity { get; set; }
        [ForeignKey("BookModel")]
        public int BookId { get; set; }
        [ForeignKey("CustomerRegistration")]
        public long UserId { get; set; }
    }
}
