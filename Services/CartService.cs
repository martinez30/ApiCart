using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiCart.Domain;
using ApiCart.Models;
using ApiCart.Repositories.Interfaces;
using ApiCart.Services.Interfaces;
using ApiCart.Utils;

namespace ApiCart.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<List<CartModel>> ListAll()
        {
            var _listAll = await _repository.ListAll();
            return _listAll.Select(c => new CartModel(c)).ToList();
        }

        public async Task<CartModel> GetByID(long id)
        {
            return new CartModel(await _repository.GetByID(id));
        }

        public async Task<CartModel> Create(List<ProductCartModel> products)
        {
            var productCart = products.Select(p => new ProductCart(p)).ToList();
            var _cart = await _repository.CreateCart(productCart);
            return new CartModel(_cart);
        }

        public async Task<FinishCartModel> Finish(int id)
        {
            var finishCartModel = new FinishCartModel();
            var _cart = await _repository.GetByID(id);

            if (_cart.Id == 0) throw new NullReferenceException();

            finishCartModel.Quantity = _cart.Products.Count();
            finishCartModel.TotalValue = _cart.Products.Sum(p => p.Product.Quantity * p.Product.Value);

            return finishCartModel;
        }

        public async Task DeleteProductFromCart(long idCart, long idProduct)
        {
            await _repository.DeleteProductByIdCart(idCart, idProduct);
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteCart(id);
        }

        public async Task<CartModel> InsertNewProducts(long idCart, ProductCartModel product)
        {
            var cart = await _repository.GetByID(idCart);

            cart.Products.Add(new ProductCart {
                CartId = idCart,
                ProductId = product.ProductId,
                Quantity = product.Quantity
            });

            return new CartModel(cart);
        }
    }
}
