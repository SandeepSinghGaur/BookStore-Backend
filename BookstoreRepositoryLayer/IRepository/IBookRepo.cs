using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRepositoryLayer.IRepository
{
    public interface IBookRepo
    {
        Book AddBook(Book book);
        IEnumerable<Book> GetAllBooks(int userId);
        Book UpdateBook(int userId, Book newBook);
        int DeleteBook(int bookId);
    }
}
