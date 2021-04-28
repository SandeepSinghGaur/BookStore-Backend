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
       
        public DbSet<BookModel> BookDB { get; set; }
        public DbSet<UserRegistration> CustomerRegister { get; set; }
        public DbSet<BookCart> CartDB { get; set; }
    }
}
