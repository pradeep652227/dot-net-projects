using ConsoleToWebAPI.Models;
using System.Collections.Generic;

namespace ConsoleToWebAPI.Repositories
{
    public interface IProductRepo
    {
        int AddProduct(ProductModel prod);
        List<ProductModel> GetAllProducts();
    }
}