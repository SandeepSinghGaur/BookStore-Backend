using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRepositoryLayer.IRepository
{
    public interface IBookRepo
    {
        BookModel AddBook(BookModel book);
        IEnumerable<BookModel> GetAllBooks(int userId);
        BookModel UpdateBook(int userId, BookModel newBook);
    }
}
