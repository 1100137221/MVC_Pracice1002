using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_Pracice1002.Models
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public Product find(int id)
        {
            return base.All().FirstOrDefault(p => p.ProductId == id);
        }
        
    }

    public interface IProductRepository : IRepository<Product>
    {

    }
}