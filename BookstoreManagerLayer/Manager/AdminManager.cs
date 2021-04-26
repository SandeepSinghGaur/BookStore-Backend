using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.Manager
{
    public class AdminManager
    {
        private readonly IAdminRepo adminRepo;
        public AdminManager(IAdminRepo adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public AdminRegistration AddAdmin(AdminRegistration objAdmin)
        {
            return this.adminRepo.AddAdmin(objAdmin);
        }
    }
}
