using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        //  Added direct reference to cartLines list to hold cart contents
        // In an enumerable and editable list of CartLine items
        public IEnumerable<CartLine> Lines => _cartLines;

        // Added a list to hold cart contents.
        private List<CartLine> _cartLines = new List<CartLine>();


        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // Completed; method adds product to cart or increases its quantity. 

            CartLine cartLine = _cartLines.FirstOrDefault(c => c.Product.Id == product.Id);
            if (cartLine == null)
            {
                _cartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                cartLine.Quantity++;
            }

        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        // Added reference to _cartLines list
        public void RemoveLine(Product product) =>
            _cartLines.RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        //  Created method to find total value of all items in cart
        public double GetTotalValue()
        {
            double cartTotal = 0.0;
            foreach (var item in _cartLines)
            {
                cartTotal += item.Product.Price * item.Quantity;
            }


            return cartTotal;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        //  Created method to find total quantity of items in cart and 
        //  Calculate average
        public double GetAverageValue()
        {
            double cartAverage;
            double cartTotal = GetTotalValue();
            int itemCount = 0;
            foreach (var item in _cartLines)
            {
                itemCount += item.Quantity;

            }
            if (itemCount == 0)
            {
                return 0;
            }
            cartAverage = cartTotal / itemCount;

            return cartAverage;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // Implemented FirstOrDefault method to find specific items in cart. 

            return _cartLines.FirstOrDefault(c => c.Product.Id == productId).Product;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        //  Simplified method to directly clear _cartLines list
        public void Clear()
        {
            _cartLines.Clear();
        }


    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
