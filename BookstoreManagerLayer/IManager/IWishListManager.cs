using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.IManager
{
    public interface IWishListManager
    {
        WishList AddItems(WishList addItem);
        string DeleteBooksFromWishlist(int WishId);
    }
}
