using BookstoreManagerLayer.IManager;
using BookstoreModelLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerManager customerManager;
        private readonly IConfiguration configuration;
        public CustomerController(ICustomerManager customerManager, IConfiguration configuration)
        {
            this.customerManager = customerManager;
            this.configuration = configuration;
        }
        [HttpPost]
        public ActionResult AddCustomer(CustomerRegistration customer)
        {
            try
            {
                var result = this.customerManager.AddCustomer(customer);
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
        [HttpGet]
        public ActionResult GetAllCustomer()
        {
            try
            {
                var result = this.customerManager.GetAllCustomer();

                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Customer Get Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Customer Get UnSuccessfully" });

            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });

            }
        }
        [HttpPost]
        [Route("login")]
        public ActionResult Login(CustomerLogin login)
        {
            try
            {
                var result = this.customerManager.Login(login);
                if (result != null)
                {
                    var token = GenrateJWTToken(result.email, result.UserId);
                    return this.Ok(new { Status = true, Message = "Customer Varified Successfully", Data = token });
                }
                return this.NotFound(new { Status = false, Message = "Customer Verified UnSuccessfully" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });

            }
        }
        private string GenrateJWTToken(string Email, long userId)
        {
            /// key getting from startup class
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"]));
            var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim("Email",Email),
                new Claim("userId",userId.ToString())
            };
            var tokenOptionOne = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(180),
                signingCredentials: signinCredentials
                );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptionOne);
            return token;
        }
        [HttpGet]
        [Route("ForgotPassword/{email}")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                ForgetPassword forget = new ForgetPassword();
                forget.email = email;
                var result = this.customerManager.ForgetPassword(forget);

                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Password Send Successfully", Data = result });
                }
                return this.NotFound(new { Status = false, Message = "Sending Password Failed" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }
    }
}
