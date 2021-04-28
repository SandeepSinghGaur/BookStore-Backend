using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.IManager
{
    public interface ICartManager
    {
        BookCart AddToCart(BookCart bookCart);
        IEnumerable<CartResponce> GetAllCarts(int userId);
        int DeletCartItem(int BookCartId);
    }
}
