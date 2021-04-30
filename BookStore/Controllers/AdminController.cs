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
    public class AdminController : Controller
    {
        private readonly IUserManager customerManager;
        private readonly IConfiguration configuration;
        public AdminController(IUserManager customerManager, IConfiguration configuration)
        {
            this.customerManager = customerManager;
            this.configuration = configuration;
        }
        [HttpPost]
        public ActionResult AddCustomer(UserRegistration customer)
        {
            try
            {
                if (customer.role == "Admin")
                {
                    var result = this.customerManager.AddUser(customer);
                    if (result != null)
                    {
                        return this.Ok(new { Status = true, Message = "Admin Added Successfully", Data = result });
                    }
                }
                    return this.BadRequest(new { Status = false, Message = "Admin Added UnSuccessfully" });

                }
            
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });

            }
        }
        [HttpPost]
        [Route("login")]
        public ActionResult Login(UserLogin login)
        {
            try
            {
                var result = this.customerManager.Login(login);
                if (result != null)
                {
                    var token = GenrateJWTToken(result.email, result.UserId, result.role);
                    return this.Ok(new { Status = true, Message = "Admin Varified Successfully", Data = token });
                }
                return this.NotFound(new { Status = false, Message = "Admin Verified UnSuccessfully" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });

            }
        }
        private string GenrateJWTToken(string Email, long userId, string role)
        {
            /// key getting from startup class
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"]));
            var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim("Email",Email),
                new Claim("userId",userId.ToString()),
                 new Claim("role",role),

            };
            var tokenOptionOne = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(180),
                signingCredentials: signinCredentials
                );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptionOne);
            return token;
        }
    }
}
