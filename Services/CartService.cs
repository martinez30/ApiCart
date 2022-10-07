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
        public GenerateID _generate = new GenerateID();

        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CartModel>> ListAll()
        {
            var _listAll = await _repository.ListAll();
            return _listAll.Select(c => new CartModel(c));
        }

        public async Task<CartModel> GetByID(long id)
        {
            var cart = await _repository.GetByID(id);
            if (cart == null) throw new NullReferenceException();
            return new CartModel(cart);
        }

        public async Task<CartModel> Create(ProductModel productModel, long idCart)
        {
            var product = new Product
            {
                Id = _generate.GenerateRandomID(),
                DataCreate = DateTime.Now,
                Name = productModel.Name,
                Code = productModel.Code,
                Quantity = productModel.Quantity,
                Value = productModel.Value
            };

            var _cart = await _repository.Create(product, idCart);
            return new CartModel(_cart);
        }

        public async Task<CartModel> Update(ProductModel productModel, long idCart)
        {
            var product = new Product
            {
                Id = productModel.Id,
                DataUpdate = DateTime.Now,
                Name = productModel.Name,
                Code = productModel.Code,
                Quantity = productModel.Quantity,
                Value = productModel.Value
            };

            var _cart = await _repository.Update(product, idCart);
            return new CartModel(_cart);
        }

        public async Task<FinishCartModel> Finish(int id)
        {
            var finishCartModel = new FinishCartModel();
            var _cart = await _repository.GetByID(id);
            if (_cart.Id == 0) throw new NullReferenceException();
            finishCartModel.Quantity = _cart.Products.Count();
            foreach (var product in _cart.Products)
            {
                finishCartModel.TotalValue += product.Value;
            }
            return finishCartModel;

        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
