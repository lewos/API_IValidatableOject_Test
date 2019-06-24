using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_IValidatableOject_Test.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_IValidatableOject_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/Product/5
        [HttpPost("post")]
        public IActionResult Get(ProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok("Value");
        }

        // POST: api/Product
        [HttpPost("post1")]
        public void Post([FromBody] string value)
        {
        }
    }
}
