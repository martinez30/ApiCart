namespace ApiCart.Domain
{
    public class Context
    {
        public static IList<Cart> Carts = new List<Cart>();

        public List<Cart> Get() => Carts.ToList();
        public void Add(Cart cart) => Carts.Add(cart);
        public void Remove(Cart cart) => Carts.Remove(cart);
        public void RemoveAll() => Carts.Clear();
    }
}
