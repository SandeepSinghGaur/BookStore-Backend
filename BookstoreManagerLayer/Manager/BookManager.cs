using BookstoreManagerLayer.IManager;
using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using BookstoreRepositoryLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.Manager
{
    public class BookManager:IBookManager
    {
        private readonly BookRepo bookRepo;
        public BookManager(IBookRepo bookRepo)
        {
            this.bookRepo = (BookRepo)bookRepo;
        }
        public BookModel AddBook(BookModel book)
        {
            return this.bookRepo.AddBook(book);
        }
        public IEnumerable<BookModel> GetAllBooks(int userId)
        {
            return this.bookRepo.GetAllBooks(userId);
        }
        public BookModel UpdateBook(int userId, BookModel newBook)
        {
            return this.bookRepo.UpdateBook(userId, newBook);
        }
        public int DeleteBook(int bookId)
        {
            return this.bookRepo.DeleteBook(bookId);
        }
    }
}
