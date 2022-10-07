namespace ApiCart.Domain
{
    public class Product : Base
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
    }
}
