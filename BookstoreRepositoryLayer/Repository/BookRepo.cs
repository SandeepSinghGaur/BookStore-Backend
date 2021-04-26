using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookstoreRepositoryLayer.Repository
{
    public class BookRepo:IBookRepo
    {
        private readonly UserContext userDbContext;
        private readonly IConfiguration configuration;
        public BookRepo(UserContext userDbContext, IConfiguration configuration)
        {
            this.userDbContext = userDbContext;
            this.configuration = configuration;

        }

        public BookModel AddBook(BookModel book)
        {
                this.userDbContext.BookDB.Add(book);
                var result = this.userDbContext.SaveChanges();
                if (result != 0)
                {
                    return book;
                }
                return null;
        }
        public IEnumerable<BookModel> GetAllBooks(int userId)
        {
            return this.userDbContext.BookDB.Where(user => user.UserId == userId ).ToList<BookModel>();
            

        }

        public BookModel UpdateBook(int userId, BookModel newBook)
        {
            BookModel book = userDbContext.BookDB.FirstOrDefault(Book => Book.BookId == newBook.BookId && Book.UserId == userId);
            book.BookName = newBook.BookName;
            book.BookImage = newBook.BookImage;
            book.AuthorName = newBook.AuthorName;
            book.Description = newBook.Description;
            book.Price = newBook.Price;
            book.Quantity = newBook.Quantity;
            book.addedTocard = newBook.addedTocard;
            userDbContext.SaveChanges();
            return book;
        }
    }

 }

