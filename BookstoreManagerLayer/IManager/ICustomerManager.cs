using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.IManager
{
    public interface ICustomerManager
    {
        CustomerRegistration AddCustomer(CustomerRegistration objCustomer);
        IEnumerable<CustomerRegistration> GetAllCustomer();
        CustomerRegistration Login(CustomerLogin login);
        string ForgetPassword(ForgetPassword forget);
    }
}
