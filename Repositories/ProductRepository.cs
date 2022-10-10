using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCart.Domain;
using ApiCart.Repositories.Interfaces;

namespace ApiCart.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public Task<Product> CreateProduct(Product product)
        {
            product.Id = generateNewId();
            _context.Products.Add(product);

            return Task.FromResult(product);
        }

        public async Task DeleteProduct(long id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if(product is null) throw new KeyNotFoundException("Product not found");

            _context.Products.Remove(product);
        }

        public Task<Product> GetByID(long id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if(product is null) throw new KeyNotFoundException("Product not found");

            return Task.FromResult(product);
        }

        public Task<List<Product>> ListAll()
        {
            return Task.FromResult(_context.Products.ToList());
        }

        private int generateNewId(){
            return _context.Products.Count() + 1;
        }
    }
}
