using BookstoreManagerLayer.IManager;
using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.Manager
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepo orderRepo;
        public OrderManager(IOrderRepo orderRepo)
        {
            this.orderRepo = orderRepo;
        }
        public OrderItems PlaceOrder(long UserId)
        {
            return this.orderRepo.PlaceOrder(UserId);
        }
    }
}
