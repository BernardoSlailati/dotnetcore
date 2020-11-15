using System.Collections.Generic;
using Login.Models;

namespace Login.Data
{
    public interface IProductsRepo
    {
        bool SaveChanges();

        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}