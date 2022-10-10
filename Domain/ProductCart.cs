using ApiCart.Models;

namespace ApiCart.Domain
{
    public class ProductCart
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public int Quantity {get;set;}

        public Product Product { get; set; }

        public ProductCart() {}

        public ProductCart(ProductCartModel model){
            ProductId = model.ProductId;
            Quantity = model.Quantity;
        }
    }
}
