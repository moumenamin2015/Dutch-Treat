using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePlayground.Data.Entities;
using CorePlayground.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CorePlayground.Controllers
{
    [Route("/api/Orders")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository repository;

        public OrdersController(IDutchRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Get()
        {
            try
            {
                return Ok(repository.GetAllOrders());
            }
            catch (Exception ex)
            {
                return BadRequest($"BadRequest: {ex}");
            }
        }
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = repository.GetOrderById(id);
                if (order != null) return Ok(order);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"BadRequest: {ex}");
            }
        }
        [HttpPost]
        public IActionResult Post(Order model)
        {
            try
            {
                repository.AddEntity(model);
                if (repository.SaveAll())
                    return Ok("Added");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest($"BadRequest: {ex}");
            }
        }

    }
}