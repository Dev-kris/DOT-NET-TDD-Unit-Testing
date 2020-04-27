using P2FixAnAppDotNetCode.Controllers;
using P2FixAnAppDotNetCode.Models.Repositories;
using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
        public List<Product> GetAllProducts()
        {
            // Changed all instances of Product array to
            // more adaptable List<Product> type. 
            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            // Implemented method to return specific product by its id. 
            return _productRepository.GetProductById(id);
        }


        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            // Method appears to work when following in debug
            // Product.Id displays the correct value
            // Quantity displays the correct quantity
            // Stock is updated inside productRepository.UpdateProductStocks
            foreach (var item in cart.Lines)
            {
                _productRepository.UpdateProductStocks(item.Product.Id, item.Quantity);

            }

            // update product inventory by using _productRepository.UpdateProductStocks() method.
        }
    }
}
