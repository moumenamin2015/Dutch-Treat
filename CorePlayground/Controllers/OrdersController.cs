using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CorePlayground.Data.Entities;
using CorePlayground.Data.Repositories;
using CorePlayground.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CorePlayground.Controllers
{
    [Route("/api/Orders")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository repository;
        private readonly IMapper mapper;

        public OrdersController(IDutchRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public IActionResult Get()
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(repository.GetAllOrders()));
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
        public IActionResult Post(OrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = mapper.Map<OrderViewModel, Order>(model);

                    if (newOrder.OrderDate == DateTime.MinValue)
                        newOrder.OrderDate = DateTime.Now;

                    repository.AddEntity(newOrder);

                    if (repository.SaveAll())
                        return Created("Added", mapper.Map<Order, OrderViewModel>(newOrder));
                    else
                        return BadRequest();
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest($"BadRequest: {ex}");
            }
        }

    }
}