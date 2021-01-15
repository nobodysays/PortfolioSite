using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSite.API
{
    public class User
    {
        public string Username { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /*[HttpPost]
        public JsonResult Post()
        {
            return new JsonResult("Work was successfully done");
        }*/
        [HttpPost]
        public JsonResult Post(User user)
        {
            return new JsonResult(user.Username);
        }
    }
}
