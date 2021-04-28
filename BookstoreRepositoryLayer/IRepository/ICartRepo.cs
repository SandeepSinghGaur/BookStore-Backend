using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRepositoryLayer.IRepository
{
    public interface ICartRepo
    {
        BookCart AddToCart(BookCart bookCart);
        IEnumerable<CartResponce> GetAllCarts(int userId);
        int DeletCartItem(int BookCartId);
        BookCart UpdateBookCount(BookCart bookCart);
    }
}
