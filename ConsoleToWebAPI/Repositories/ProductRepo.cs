using ConsoleToWebAPI.Models;
using System.Collections.Generic;
namespace ConsoleToWebAPI.Repositories

{
    public class ProductRepo : IProductRepo
    {
       
        private List<ProductModel> products = new List<ProductModel>();
        public int AddProduct(ProductModel prod)
        {
            prod.Id = products.Count + 1;
            products.Add(prod);
            return prod.Id;
        }

        public List<ProductModel> GetAllProducts()
        {
            return products;
        }

    }
}
