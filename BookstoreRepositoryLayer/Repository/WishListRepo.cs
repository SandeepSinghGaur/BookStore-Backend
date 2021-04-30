using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRepositoryLayer.Repository
{
    public class WishListRepo:IWishListRepo
    {
        private readonly UserContext userDbContext;
        private readonly IConfiguration configuration;
        public WishListRepo(UserContext userDbContext, IConfiguration configuration)
        {
            this.userDbContext = userDbContext;
            this.configuration = configuration;

        }

        public WishList AddItems(WishList addItem)
        {
            try
            {
                userDbContext.WishDB.Add(addItem);
                var add = userDbContext.SaveChanges();

                if (add > 0)
                {
                    return addItem;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Adding Book" + e.Message);
            }
        }

        public string DeleteBooksFromWishlist(int WishId)
        {
            try
            {
                WishList deleteResult = userDbContext.WishDB.Find(WishId);
                if (deleteResult != null)
                {
                    userDbContext.WishDB.Remove(deleteResult);
                    userDbContext.SaveChangesAsync();
                    return "RecordDeleted";
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Removing Book" + e.Message);
            }
        }
    }
}
