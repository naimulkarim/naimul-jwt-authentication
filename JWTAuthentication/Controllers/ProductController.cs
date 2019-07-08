using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        // GET api/values
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {

            var currentUser = HttpContext.User;

            var designation = string.Empty;
            if (currentUser.HasClaim(c => c.Type == "Designation"))
            {
                designation = currentUser.Claims.FirstOrDefault(c => c.Type == "Designation")?.Value;
            
            }

            if (designation == "manager")
            {
                return new string[] { "product A", "product B" };
            }
            else
            {
                return new string[] { "not allowed" };
            }


        }

     
    }
}
