﻿using BookstoreModelLayer;
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

        public Book AddBook(Book book)
        {
                this.userDbContext.BookDB.Add(book);
                var result = this.userDbContext.SaveChanges();
                if (result != 0)
                {
                    return book;
                }
                return null;
        }

        public IEnumerable<Book> GetAllBooks(int userId)
        {
            return this.userDbContext.BookDB.Where(user => user.UserId == userId ).ToList<Book>();
            

        }

        public Book UpdateBook(int userId, Book newBook)
        {
            Book book = userDbContext.BookDB.FirstOrDefault(Book => Book.BookId == newBook.BookId && Book.UserId == userId);
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
        public int DeleteBook(int bookId)
        {
            Book book = userDbContext.BookDB.FirstOrDefault(Book => Book.BookId == bookId);
            this.userDbContext.BookDB.Remove(book);
            this.userDbContext.SaveChanges();
            return bookId;

        }
    }

 }

