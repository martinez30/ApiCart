using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiCart.Domain;
using ApiCart.Repositories.Interfaces;
using ApiCart.Utils;

namespace ApiCart.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IProductRepository _productRepository;
        private readonly Context _context;

        public CartRepository(Context context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public async Task<List<Cart>> ListAll(){
            
            var carts = _context.Carts.ToList();
            var products = await _productRepository.ListAll();

            carts.ForEach(cart => {
                cart.Products.ForEach(productcart => {
                    productcart.Product = products.FirstOrDefault(p => p.Id == productcart.ProductId);
                });
            });

            return await Task.FromResult(carts);
        }

        public async Task<Cart> GetByID(long id)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == id);

            if(cart is null) throw new KeyNotFoundException("Cart not found");

            foreach(ProductCart product in cart.Products){
                product.Product = await _productRepository.GetByID(product.ProductId);
            }

            return await Task.FromResult(cart);
        }

        public async Task<Cart> CreateCart(List<ProductCart> products)
        {
            Cart cart = new Cart();
            cart.Id = generateNewId();

            Product product;
            foreach(ProductCart productCart in products){
                product = _context.Products.FirstOrDefault(p => p.Id == productCart.ProductId);

                if(product is null) throw new KeyNotFoundException("Product not found");

                cart.Products.Add(new ProductCart {
                    CartId = cart.Id,
                    ProductId = product.Id,
                    Quantity = productCart.Quantity,
                    Product = product
                });
            }

            _context.Carts.Add(cart);
            return await Task.FromResult(cart);
        }

        public async Task<Cart> IncludeNewProduct(long id, long idProduct)
        {
            Cart cart = _context.Carts.FirstOrDefault(c => c.Id == id);
            if(cart is null) throw new KeyNotFoundException("Cart not found");

            Product product = await _productRepository.GetByID(idProduct);
            if(product is null) throw new KeyNotFoundException("Product not found");

            _context.Carts.FirstOrDefault(c => c.Id == id)?.Products.Add(new ProductCart{
                CartId = cart.Id,
                ProductId = product.Id,
                Product = product
            });

            return await Task.FromResult(cart);
        }

        public async Task DeleteProductByIdCart(long idCart, long idProduct)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == idCart);
            if (cart == null) throw new FileNotFoundException("Carrinho não encontrado");

            var productCart = cart.Products.FirstOrDefault(p => p.ProductId == idProduct && p.CartId == idCart);
            if (productCart == null) throw new FileNotFoundException("Produto não encontrado no carrinho");

            _context.Carts.FirstOrDefault(c => c.Id == idCart)?.Products.Remove(productCart);
        }

        public async Task DeleteCart(long id)
        {
            _context.Carts.Remove(_context.Carts.FirstOrDefault(c => c.Id == id));
        }
    
        private int generateNewId(){
            return _context.Carts.Count() + 1;
        }
    }
}
