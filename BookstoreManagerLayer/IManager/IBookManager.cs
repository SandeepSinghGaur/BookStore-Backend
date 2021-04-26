using BookstoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagerLayer.IManager
{
    public interface IBookManager
    {
        BookModel AddBook(BookModel book);
        IEnumerable<BookModel> GetAllBooks(int userId);
    }
}
