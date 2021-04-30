using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRepositoryLayer.IRepository
{
    public interface IOrderRepo
    {
        OrderItems PlaceOrder(long UserId);
    }
}
