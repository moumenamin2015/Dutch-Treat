using CorePlayground.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
        private readonly Microsoft.AspNetCore.Identity.UserManager<StoreUser> _userManager;

        public DutchSeeder(DutchContext ctx, IHostingEnvironment hosting, UserManager<StoreUser> userManager)
        {
            this.ctx = ctx;
            this.hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            ctx.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("moumen.amin@hotmail.com");

            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Moumen",
                    LastName = "Fawzy",
                    UserName = "moumen.amin",
                    Email = "moumen.amin@hotmail.com"
                };
                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in Seeding");
                }
            }

            if (!ctx.Products.Any())
            {
                var filePath = Path.Combine(hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                ctx.Products.AddRange(products);
                ctx.SaveChanges();
            }
            var order = ctx.Orders.FirstOrDefault();
            if (order == null)
            {
                order = new Order()
                {
                    OrderDate = DateTime.UtcNow,
                    OrderNumber = "123",
                    User = user,
                    Items = new List<OrderItem>()
                        {
                            new OrderItem()
                            {
                                Product = ctx.Products.First(),
                                Quantity = 4,
                                UnitPrice = ctx.Products.First().Price
                            }
                        }
                };
                ctx.Orders.Add(order);
                ctx.SaveChanges();
            }
        }
    }
}
