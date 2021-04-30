using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.IManager
{
    public interface IOrderManager
    {
        OrderItems PlaceOrder(long UserId);
    }
}
