using BookstoreManagerLayer.IManager;
using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.Manager
{
    public class WishListManager : IWishListManager
    {
        private readonly IWishListRepo wishListRepo;
        public WishListManager(IWishListRepo wishListRepo)
        {
            this.wishListRepo = wishListRepo;
        }
        public WishList AddItems(WishList addItem)
        {
            return this.wishListRepo.AddItems(addItem);
        }

        public string DeleteBooksFromWishlist(int WishId)
        {
            return this.wishListRepo.DeleteBooksFromWishlist(WishId);
        }
    }
}
