﻿using BookstoreModelLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRepositoryLayer.Repository
{
   public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
          : base(options)
        {
        }
       
        public DbSet<BookModel> Book { get; set; }
        public DbSet<CustomerRegistration> CustomerRegister { get; set; }
    }
}
