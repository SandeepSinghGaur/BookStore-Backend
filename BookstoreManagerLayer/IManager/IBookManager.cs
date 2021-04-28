using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.IManager
{
    public interface IBookManager
    {
        Book AddBook(Book book);
        IEnumerable<Book> GetAllBooks(int userId);
        Book UpdateBook(int userId, Book newBook);
        int DeleteBook(int bookId);
    }
}
