using ApiCart.Domain;

namespace ApiCart.Models
{
    public class CartModel
    {
        public long Id { get; set; }
        public List<ProductModel> Products = new List<ProductModel>();

        public CartModel(Cart cart)
        {
            this.Id = cart.Id;
            this.Products = cart.Products.Select(c => new ProductModel(c)).ToList();
        }
    }
}
