using BlazorServerDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerDemo.Services
{
    public class ProductsService : IProductsService
    {
        private readonly BlazortestContext _context;

        public ProductsService(BlazortestContext context)
        {
            _context = context;
        }

        public async  Task<List<Products>> GetProducts()
        {
           
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> CreateProduct(Products product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return await Task.FromResult(product);
        }

        public Task<bool> UpdateProduct(Products product)
        {
            var productCheck = _context.Products.Where(x => x.Id == product.Id).FirstOrDefault();
            if (productCheck != null)
            {
                productCheck.ProductName = product.ProductName;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<bool> DeleteProduct(Products product)
        {
            var productCheck = _context.Products.Where(x => x.Id == product.Id).FirstOrDefault();
            if (productCheck != null)
            {
                _context.Products.Remove(productCheck);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

    }
}
