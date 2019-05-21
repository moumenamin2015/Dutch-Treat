using CorePlayground.Data;
using CorePlayground.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlayground.Controllers
{
    public class AppController : Controller
    {
        private readonly DutchContext context;

        public AppController(DutchContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var products = context.Products.OrderBy(p => p.Category);
            return View(products.ToList());
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactUs([FromForm] ContactUsViewModel model)
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
