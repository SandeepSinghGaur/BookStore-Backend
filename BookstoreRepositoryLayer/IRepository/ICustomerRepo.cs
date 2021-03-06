using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRepositoryLayer.IRepository
{
    public interface ICustomerRepo
    {
        CustomerDetails AddCustomerDetails(CustomerDetails customerDetails);
        CustomerDetails UpdateCustomerDetails(CustomerDetails update);
        IEnumerable<CustomerResponse> GetCustomerAddress(int userId);
    }
}
