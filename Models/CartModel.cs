using ApiCart.Domain;

namespace ApiCart.Models
{
    public class CartModel : BaseModel
    {
        public IList<ProductModel> Products = new List<ProductModel>();

        public CartModel(Cart cart)
        {
            this.Id = cart.Id;
            this.DataCreate = cart.DataCreate;
            this.DataUpdate = cart.DataUpdate;
            this.Products = cart.Products.Select(c => new ProductModel(c)).ToList();
        }
    }
}
