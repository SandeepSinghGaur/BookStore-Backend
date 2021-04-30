using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.IManager
{
    public interface ICartManager
    {
        BookCart AddToCart(BookCart bookCart);
        IEnumerable<CartResponse> GetAllCarts(int userId);
        int DeletCartItem(int BookCartId);
        BookCart UpdateBookCount(BookCart bookCart);
    }
}
