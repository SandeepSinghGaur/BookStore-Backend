﻿using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRepositoryLayer.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly UserContext userDbContext;
        private readonly IConfiguration configuration;
        public CustomerRepo(UserContext userDbContext, IConfiguration configuration)
        {
            this.userDbContext = userDbContext;
            this.configuration = configuration;

        }
        public CustomerDetails AddCustomerDetails(CustomerDetails customerDetails)
        {
            try
            {
                this.userDbContext.CustomerDB.Add(customerDetails);
                int result = this.userDbContext.SaveChanges();
                if (result > 0)
                {
                    return customerDetails;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error while AddCustomerDetails " + e.Message);
            }
        }
    }
}