using BlazorServerDemo.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerDemo.Services
{
    public interface IProductsService
    {
        Task<List<Products>> GetProducts();
        Task<Products> CreateProduct(Products product);
        Task<bool> UpdateProduct(Products product);
        Task<bool> DeleteProduct(Products product);
    }
}
