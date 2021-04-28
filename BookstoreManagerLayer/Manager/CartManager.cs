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
        private readonly CartRepo cartRepo;
        public CartManager(ICartRepo cartRepo)
        {
            this.cartRepo = (CartRepo)cartRepo;
        }
        public BookCart AddToCart(BookCart bookCart)
        {
            return this.cartRepo.AddToCart(bookCart);
        }

        public IEnumerable<CartResponce> GetAllCarts(int userId)
        {
            return (IEnumerable<CartResponce>)this.cartRepo.GetAllCarts(userId);
        }
        public int DeletCartItem(int BookCartId)
        {
            return  this.cartRepo.DeletCartItem(BookCartId);
            
        }
    }
}
