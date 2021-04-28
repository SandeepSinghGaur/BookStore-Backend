using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookstoreRepositoryLayer.Repository
{
    public class CartRepo : ICartRepo
    {
        private readonly UserContext userDbContext;
        private readonly IConfiguration configuration;
        public CartRepo(UserContext userDbContext, IConfiguration configuration)
        {
            this.userDbContext = userDbContext;
            this.configuration = configuration;

        }
        public BookCart AddToCart(BookCart bookCart)
        {
            try
            {
                this.userDbContext.CartDB.Add(bookCart);
                var result = this.userDbContext.SaveChanges();
                if (result!= 0)
                {
                    return bookCart;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error while AddToCart " + e.Message);
            }
        }

        public IEnumerable<CartResponce> GetAllCarts(int userId)
        {
                try
                {
                    List<CartResponce> getResult = new List<CartResponce>();
                    var result = from BookModel in userDbContext.BookDB
                                 join CartModel in userDbContext.CartDB
                                 on BookModel.BookId equals CartModel.BookId

                                 select new CartResponce()
                                 {
                                     BookId = BookModel.BookId,
                                     BookName = BookModel.BookName,
                                     AuthorName = BookModel.AuthorName,
                                     BookPrice = (int)BookModel.Price,
                                     BookQuantity = CartModel.BookQuantity,
                                     BookImage = BookModel.BookImage,
                                     BookDescription = BookModel.Description,
                                     CartId = CartModel.BookCartId,
                                     UserId = (int)CartModel.UserId,
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
                    throw new Exception("Error while Get_Cart_Item " + e.Message);
                }
            }
        public int DeletCartItem(int BookCartId)
        {
            try
            {
                var deletCartItem = userDbContext.CartDB.Find(BookCartId);
                if (deletCartItem != null)
                {
                    userDbContext.CartDB.Remove(deletCartItem);
                    userDbContext.SaveChanges();
                    return BookCartId;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw new Exception("Error while Deleting Cart Item " + e.Message);
            }
        }

        public BookCart UpdateBookCount(BookCart bookCart)
        {
            try
            {
                var update = userDbContext.CartDB.Where(x => x.BookCartId == bookCart.BookCartId).FirstOrDefault();
                update.BookQuantity = bookCart.BookQuantity;
                userDbContext.Update(update);
                var result = userDbContext.SaveChanges();
                if (result > 0)
                {
                    return update;
                }
                return null;

            }
            catch (Exception e)
            {
                throw new Exception("Error while Updating Book Quntity!!!" + e.Message);
            }
        }
    }
    }

