using BookstoreManagerLayer.IManager;
using BookstoreModelLayer;
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
    public class CustomersController : Controller
    {
        private readonly ICustomerManager customerManager;
        private readonly IConfiguration configuration;
        public CustomersController(ICustomerManager customerManager, IConfiguration configuration)
        {
            this.customerManager = customerManager;
            this.configuration = configuration;
        }
        [HttpPost]
        public ActionResult AddCustomerDetails(CustomerDetails customerDetails)
        {
            try
            {
                var result = this.customerManager.AddCustomerDetails(customerDetails);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Customer Added Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Customer Added UnSuccessfully" });

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });

            }
        }
        [HttpPut]
        public IActionResult UpdateCustomerDetails(CustomerDetails updates)
        {
            try
            {
                var update = this.customerManager.UpdateCustomerDetails(updates);
                if (update != null)
                {
                    return this.Ok(new { Status = true, Message = "Address Updated Succesfully", Data = update });
                }
                return this.NotFound(new { Status = false, Message = "Error While Updating Address" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });

            }
        }
        [HttpGet]
        public ActionResult GetCustomerAddress()
        {
            try
            {
                int userId = TokenUserId();
                var result = this.customerManager.GetCustomerAddress(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "All Customer Address Get Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "All Customer Address Get SuccessFully" });
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
    }
}
