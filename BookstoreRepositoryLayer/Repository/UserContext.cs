using BookstoreModelLayer;
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
       
        
        public DbSet<UserRegistration> UserDB { get; set; }
        public DbSet<Book> BookDB { get; set; }
        public DbSet<BookCart> CartDB { get; set; }
        public DbSet<CustomerDetails> CustomerDB { get; set; }
        public DbSet<OrderItems> OrderDB { get; set; }
    }
}
