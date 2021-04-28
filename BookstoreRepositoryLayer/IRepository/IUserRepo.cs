using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRepositoryLayer.IRepository
{
   public interface IUserRepo
    {
        UserRegistration AddUser(UserRegistration objCustomer);
        IEnumerable<UserRegistration> GetAllUser();
        UserRegistration Login(UserLogin login);
        string ForgetPassword(ForgetPassword forget);
    }
}
