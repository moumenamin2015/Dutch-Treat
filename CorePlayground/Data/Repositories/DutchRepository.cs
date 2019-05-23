﻿using CorePlayground.Data.Entities;
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

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products
                .OrderBy(p => p.Title).ToList();
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
