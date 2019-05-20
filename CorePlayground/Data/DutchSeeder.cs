using CorePlayground.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CorePlayground.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext ctx;
        private readonly IHostingEnvironment hosting;

        public DutchSeeder(DutchContext ctx, IHostingEnvironment hosting)
        {
            this.ctx = ctx;
            this.hosting = hosting;
        }

        public void Seed()
        {
            ctx.Database.EnsureCreated():
            if (!ctx.Products.Any())
            {
                var filePath = Path.Combine(hosting.ContentRootPath, "/data/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                ctx.Products.AddRange(products);

                ctx.SaveChanges();
            }
        }
    }
}
