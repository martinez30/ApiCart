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

        public async Task<List<Cart>> ListAll()
        {
            return await Task.FromResult(_context.Get());
        }

        public async Task<Cart> GetByID(long id)
        {
            var cart = _context.Get().Where(c => c.Id == id).FirstOrDefault();
            return await Task.FromResult(cart ?? new Cart { Id = 0});
        }

        public async Task<Cart> Create(Product product, long id)
        {
            var cart = _context.Get().Where(c => c.Id == id).FirstOrDefault();
            if(cart == null)
            {
                cart = new Cart { Id = id, Products = new List<Product>()};
                cart.Products.Add(product);
                _context.Add(cart);
            }
            else
            {
                cart.Products?.Add(product);
            }

            return await Task.FromResult(cart);
        }

        public async Task DeleteProduct(long idCart, long idProduct)
        {
            var cart = _context.Get().Where(c => c.Id == idCart).FirstOrDefault();
            if (cart == null) throw new FileNotFoundException("Carrinho não encontrado");
            var product = cart?.Products.Where(c => c.Id == idProduct).FirstOrDefault();
            if (product == null) throw new FileNotFoundException("Produto não encontrado");
            cart.Products.Remove(product);
            await Task.FromResult(true);
        }

        public async Task Delete(long id)
        {
            var cart = _context.Get().Where(c => c.Id == id).FirstOrDefault();
            if (cart == null) throw new FileNotFoundException("Carrinho não encontrado");
            _context.Remove(cart);
            await Task.FromResult(true);
        }
    }
}
