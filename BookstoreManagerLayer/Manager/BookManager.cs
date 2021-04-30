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
        private readonly IBookRepo bookRepo;
        public BookManager(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }
        public Book AddBook(Book book)
        {
            return this.bookRepo.AddBook(book);
        }
        public IEnumerable<Book> GetAllBooks(int userId)
        {
            return this.bookRepo.GetAllBooks(userId);
        }
        public Book UpdateBook(int userId, Book newBook)
        {
            return this.bookRepo.UpdateBook(userId, newBook);
        }
        public int DeleteBook(int bookId)
        {
            return this.bookRepo.DeleteBook(bookId);
        }
    }
}
