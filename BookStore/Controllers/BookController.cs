using BookstoreManagerLayer.IManager;
using BookstoreModelLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookManager bookManager;
        private readonly IConfiguration configuration;
        public BookController(IBookManager bookManager, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.bookManager = bookManager;
        }
        [HttpPost]
        public ActionResult AddBook(BookModel book)
        {
            try
            {
                int userId = TokenUserId();
                book.UserId = userId;
                
                var result = this.bookManager.AddBook(book);
                if (result != null )
                {
                    return this.Ok(new { Status = true, Message = "Book Added Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Book Added UnSuccessfully" });

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });

            }
        }
        private int TokenUserId()
        {
            return Convert.ToInt32(User.FindFirst("userId").Value);
        }
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            try
            {
                int userId = TokenUserId();
                var result = this.bookManager.GetAllBooks(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "All Book Get Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "All Book Get SuccessFully" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }

        }
        [HttpPut]
        public ActionResult UpdateBook(BookModel newBook)
        {
            try
            {
                int userId = TokenUserId();
                var result = this.bookManager.UpdateBook(userId, newBook);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Update Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Book Update UnSuccessFully" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }

        }
        [HttpDelete]
        [Route("{bookId}")]
        public ActionResult DeleteBook(int bookId)
        {
            try
            {
                var result = this.bookManager.DeleteBook(bookId);
                if (result != 0)
                {
                    return this.Ok(new { Status = true, Message = "Book Deleted Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Book Deleted UnSuccessFully" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }

        }
    }
}
