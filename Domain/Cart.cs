namespace ApiCart.Domain
{
    public class Cart
    {
        public long Id { get; set; }
        public List<Product> Products = new List<Product>();
    }
}
