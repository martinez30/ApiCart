using System.Collections.Generic;

namespace ApiCart.Domain
{
    public class Cart
    {
        public long Id { get; set; }
        public List<ProductCart> Products = new List<ProductCart>();
    }
}
