using System.Collections.Generic;
using System.Linq;
using ApiCart.Domain;

namespace ApiCart.Models
{
    public class CartModel
    {
        public long Id { get; set; }
        public List<ProductModel> Products { get; set; }

        public CartModel(Cart cart)
        {
            this.Id = cart.Id;
            this.Products = cart.Products.Select(c => new ProductModel(c.Product)).ToList();
        }
    }
}
