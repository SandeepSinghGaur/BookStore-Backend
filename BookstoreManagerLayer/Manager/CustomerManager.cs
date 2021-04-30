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
        private readonly ICustomerRepo customerRepo;
        public CustomerManager(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        public CustomerDetails AddCustomerDetails(CustomerDetails customerDetails)
        {
            return this.customerRepo.AddCustomerDetails(customerDetails);
        }

        public CustomerDetails UpdateCustomerDetails(CustomerDetails update)
        {
            return this.customerRepo.UpdateCustomerDetails(update);
        }
    }
}
