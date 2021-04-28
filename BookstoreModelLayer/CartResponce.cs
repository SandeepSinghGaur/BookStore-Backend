using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreModelLayer
{
    public class CartResponce
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string BookDescription { get; set; }

        public string BookImage { get; set; }

        public int BookQuantity { get; set; }

        public string AuthorName { get; set; }

        public int BookPrice { get; set; }

        public int UserId { get; set; }

        public int CartId { get; set; }
    }
}
