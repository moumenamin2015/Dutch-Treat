using CorePlayground.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePlayground.Data.Repositories
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext context;

        public DutchRepository(DutchContext context)
        {
            this.context = context;
        }

        public void AddEntity(object model)
        {
            context.Add(model);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return context.Orders
                          .Include(o => o.Items)
                          .ThenInclude(p => p.Product)
                          .ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products
                          .OrderBy(p => p.Title).ToList();
        }

        public Order GetOrderById(int id)
        {
            return context.Orders
                          .Include(o => o.Items)
                          .Where(o => o.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return context.Products
                          .Where(p => p.Category == category).ToList();
        }

        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }
    }
}
