using System.Collections.Generic;
using CorePlayground.Data.Entities;

namespace CorePlayground.Data.Repositories
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}