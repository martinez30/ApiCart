using ApiCart.Domain;
using ApiCart.Repositories.Interfaces;

namespace ApiCart.Repositories
{
    public class CartRepository : ICartRepository
    {
        Context _context;

        public CartRepository()
        {
            _context = new Context();
        }

        public async Task<IList<Cart>> ListAll()
        {
            return await Task.FromResult(_context.Carts);
        }

        public async Task<Cart> GetByID(long id)
        {
            var cart = _context.Carts.Where(c => c.Id == id).FirstOrDefault();
            return await Task.FromResult(cart ?? new Cart { Id = 0});
        }

        public async Task<Cart> Create(Product product, long id)
        {
            var cart = _context.Carts.Where(c => c.Id == id).FirstOrDefault();
            if(cart == null)
            {
                cart = new Cart { Id = id, DataCreate = DateTime.Now, Products = new List<Product>()};
                cart.Products.Add(product);
                _context.Carts.Add(cart);
            }
            else
            {
                cart.Products?.Add(product);
                cart.DataUpdate = DateTime.Now;
            }

            return await Task.FromResult(cart);
        }

        public async Task<Cart> Update(Product product, long id)
        {
            var cart = _context.Carts.Where(c => c.Id == id).FirstOrDefault() ?? new Cart();
            cart.DataUpdate = DateTime.Now;
            cart.Products?.Add(product);

            _context.Carts.Add(cart);

            return await Task.FromResult(cart);
        }

        public async Task<bool> Delete(long id)
        {
            var cart = _context.Carts.Where(c => c.Id == id).FirstOrDefault();
            if (cart == null) return await Task.FromResult(false);
            _context.Carts.Remove(cart);
            return await Task.FromResult(true);
        }
    }
}
