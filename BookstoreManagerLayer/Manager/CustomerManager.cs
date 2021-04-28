using BookstoreManagerLayer.IManager;
using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using BookstoreRepositoryLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.Manager
{
    public class CustomerManager : ICustomerManager
    {
        private readonly CustomerRepo customerRepo;
        public CustomerManager(ICustomerRepo customerRepo)
        {
            this.customerRepo = (CustomerRepo)customerRepo;
        }
        public CustomerDetails AddCustomerDetails(CustomerDetails customerDetails)
        {
            return this.customerRepo.AddCustomerDetails(customerDetails);
        }
    }
}
