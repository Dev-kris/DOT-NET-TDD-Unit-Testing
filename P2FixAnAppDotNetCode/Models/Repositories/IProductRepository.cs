using System.Collections.Generic;
namespace P2FixAnAppDotNetCode.Models.Repositories
{
    // Added interface reference to GetProductByID.
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        void UpdateProductStocks(int productId, int quantityToRemove);
        Product GetProductById(int id);
    }
}
