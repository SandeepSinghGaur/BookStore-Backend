using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookstoreModelLayer
{
    public class BookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
        public int addedTocard { get; set; }
        [ForeignKey("CustomerRegistration")]
        public long UserId { get; set; }
    }
}
