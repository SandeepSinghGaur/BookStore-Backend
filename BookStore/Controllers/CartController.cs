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
    public class CartController : Controller
    {
        private readonly ICartManager cartManager;
        private readonly IConfiguration configuration;
        public CartController(ICartManager cartManager, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.cartManager = cartManager;
        }
        [HttpPost]
        public ActionResult AddToCart(BookCart bookCart)
        {
            try
            {
                int userId = TokenUserId();
                bookCart.UserId = userId;

                var result = this.cartManager.AddToCart(bookCart);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Added into Cart Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Book Added into Cart UnSuccessfully" });

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
        public ActionResult GetAllCarts()
        {
            try
            {
                int userId = TokenUserId();
                var result = this.cartManager.GetAllCarts(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "All Book Cart Get Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "All Book Cart Get SuccessFully" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }

        }
        [HttpDelete]
        //[Route("{cartId}")]
        public ActionResult DeletCartItem(int BookCartId)
        {
            try
            {
                var result = this.cartManager.DeletCartItem(BookCartId);
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
