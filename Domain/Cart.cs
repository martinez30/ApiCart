namespace ApiCart.Domain
{
    public class Cart : Base
    {
        public IList<Product> Products = new List<Product>();
    }
}
