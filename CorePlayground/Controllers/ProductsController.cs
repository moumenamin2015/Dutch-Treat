using CorePlayground.Data;
using CorePlayground.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePlayground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IDutchRepository repository;

        public ProductsController(IDutchRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                return BadRequest($"BadRequest: {ex}");
            }
        }
    }
}
