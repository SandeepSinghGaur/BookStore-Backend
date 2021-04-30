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
    [Authorize(Roles = "User")]
    public class WishListController : Controller
    {
        private readonly IWishListManager wishListManager;
        private readonly IConfiguration configuration;
        public WishListController(IWishListManager wishListManager, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.wishListManager = wishListManager;
        }
       [HttpPost]
        public ActionResult AddItems(WishList addItem)
        {
            try
            {
                int userId = TokenUserId();
                addItem.UserId = userId;

                var result = this.wishListManager.AddItems(addItem);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Added into WishList Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Book Added into WishList UnSuccessfully" });

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
        [HttpDelete]
        public ActionResult DeleteBooksFromWishlist(int WishId)
        {
            try
            {
                var result = this.wishListManager.DeleteBooksFromWishlist(WishId);
                if (result != null)
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
