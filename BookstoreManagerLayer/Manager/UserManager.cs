using BookstoreManagerLayer.IManager;
using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo userRepo;
        public UserManager(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public UserRegistration AddUser(UserRegistration objCustomer)
        {
            return this.userRepo.AddUser(objCustomer);
        }

        public IEnumerable<UserRegistration> GetAllUser()
        {
            return this.userRepo.GetAllUser();
        }
        public UserRegistration Login(UserLogin login)
        {
            return this.userRepo.Login(login);
        }
        public string ForgetPassword(ForgetPassword forget)
        {
            return this.userRepo.ForgetPassword(forget);
        }
    }
}
