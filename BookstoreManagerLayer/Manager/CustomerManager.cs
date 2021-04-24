using BookstoreManagerLayer.IManager;
using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
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

        public CustomerRegistration AddCustomer(CustomerRegistration objCustomer)
        {
            return this.customerRepo.AddCustomer(objCustomer);
        }

        public IEnumerable<CustomerRegistration> GetAllCustomer()
        {
            return this.customerRepo.GetAllCustomer();
        }
        public CustomerRegistration Login(CustomerLogin login)
        {
            return this.customerRepo.Login(login);
        }
        public string ForgetPassword(ForgetPassword forget)
        {
            return this.customerRepo.ForgetPassword(forget);
        }
    }
}
