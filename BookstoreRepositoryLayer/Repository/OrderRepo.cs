using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRepositoryLayer.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly UserContext userDbContext;
        private readonly IConfiguration configuration;
        public OrderRepo(UserContext userDbContext, IConfiguration configuration)
        {
            this.userDbContext = userDbContext;
            this.configuration = configuration;

        }

        public OrderItems PlaceOrder(long UserId)
        {
            throw new NotImplementedException();
        }
    }
}
