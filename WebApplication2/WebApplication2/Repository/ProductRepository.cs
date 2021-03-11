using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DBContexts;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteProduct(int ProductId)
        {
            var product = _dbContext.Products.Find(ProductId);
            _dbContext.Products.Remove(product); Save();
        }

        public Product GetProductByID(int ProductId)
        {
            return _dbContext.Products.Find(ProductId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void InsertProduct(Product Product)
        {
            _dbContext.Add(Product); Save();
        }

        public void Save()
        {
             _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product Product)
        {
            _dbContext.Entry(Product).State = EntityState.Modified; Save();
        }
    }

}






