using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.IManager
{
    public interface ICustomerManager
    {
        CustomerDetails AddCustomerDetails(CustomerDetails customerDetails);
        CustomerDetails UpdateCustomerDetails(CustomerDetails update);
        IEnumerable<CustomerResponse> GetCustomerAddress(int userId);
    }
}
