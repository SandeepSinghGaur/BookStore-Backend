using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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

        public CustomerDetails UpdateCustomerDetails(CustomerDetails update)
        {
            try
            {
                if (update.UserId > 0)
                {
                    userDbContext.Entry(update).State = EntityState.Modified;
                    userDbContext.SaveChanges();
                    return update;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Updating Customer Record" + e.Message);
            }
        }
        public IEnumerable<CustomerResponse> GetCustomerAddress(int userId)
        {
            try
            {
                List<CustomerResponse> getResult = new List<CustomerResponse>();
                var result = from CustomerModel in userDbContext.CustomerDB
                             join AddressType in userDbContext.AddressDB
                             on CustomerModel.AddressTypeId equals AddressType.AddressTypeId

                             select new CustomerResponse()
                             {
                                 CustomerId = CustomerModel.CustomerId,
                                 Fullname = CustomerModel.Fullname,
                                 Phone = CustomerModel.Phone,
                                 Pincode = CustomerModel.Pincode,
                                 City = CustomerModel.City,
                                 State = CustomerModel.State,
                                 Email = CustomerModel.Email,
                                 FullAddress = CustomerModel.FullAddress,
                                 CustomerAddressType = AddressType.CustomerAddressType,
                                 UserId = CustomerModel.UserId,
                             };
                foreach (var data in result)
                {
                    if (data.UserId == userId)
                    {
                        getResult.Add(data);
                    }
                   
                }
                return getResult;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Getting Customer Record" + e.Message);
            }
        }
    }
}
    

