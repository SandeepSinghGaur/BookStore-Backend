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
    public class AdminController : Controller
    {
        private readonly IAdminManager adminManager;
        private readonly IConfiguration configuration;
        public AdminController(IAdminManager adminManager, IConfiguration configuration)
        {
            this.adminManager = adminManager;
            this.configuration = configuration;
        }
        [HttpPost]
        public ActionResult AddAdmin(AdminRegistration admin)
        {
            try
            {
                var result = this.adminManager.AddAdmin(admin);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Admin Added Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Admin Added UnSuccessfully" });

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });

            }
        }
    }
}
