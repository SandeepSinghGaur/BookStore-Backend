using BookstoreManagerLayer.IManager;
using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using BookstoreRepositoryLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.Manager
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepo cartRepo;
        public CartManager(ICartRepo cartRepo)
        {
            this.cartRepo = cartRepo;
        }
        public BookCart AddToCart(BookCart bookCart)
        {
            return this.cartRepo.AddToCart(bookCart);
        }

        public IEnumerable<CartResponse> GetAllCarts(int userId)
        {
            return (IEnumerable<CartResponse>)this.cartRepo.GetAllCarts(userId);
        }
        public int DeletCartItem(int BookCartId)
        {
            return  this.cartRepo.DeletCartItem(BookCartId);
            
        }

        public BookCart UpdateBookCount(BookCart bookCart)
        {
            return this.cartRepo.UpdateBookCount(bookCart);
        }
    }
}
