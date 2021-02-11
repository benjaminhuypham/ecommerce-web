using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Repository
{
    public class ProductData : IDataRepository<Product>
    {
        private readonly ShopDBContext _context;
        public ProductData(ShopDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }
        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(e => e.Id == id);
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product, Product entity)
        {
            product.name = entity.name;
            product.price = entity.price;
            product.description = entity.description; 
            _context.SaveChanges();
        }
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
