using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRepositoryLayer.IRepository
{
    public interface IWishListRepo
    {
        WishList AddItems(WishList addItem);
        string DeleteBooksFromWishlist(int WishId);
    }
}
