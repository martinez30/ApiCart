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

        public async Task<List<CartModel>> ListAll()
        {
            var _listAll = await _repository.ListAll();
            return _listAll.Select(c => new CartModel(c)).ToList();
        }

        public async Task<CartModel> GetByID(long id)
        {
            var cart = await _repository.GetByID(id);
            if (cart.Id == 0) throw new FileNotFoundException();
            return new CartModel(cart);
        }

        public async Task<CartModel> Create(ProductModel productModel, long idCart)
        {
            if (idCart == 0) throw new ArgumentException("ID do carrinho é inválido");
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


        public async Task<FinishCartModel> Finish(int id)
        {
            var finishCartModel = new FinishCartModel();
            var _cart = await _repository.GetByID(id);
            if (_cart.Id == 0) throw new NullReferenceException();
            foreach (var product in _cart.Products)
            {
                finishCartModel.Quantity += product.Quantity;
                finishCartModel.TotalValue += product.Value * product.Quantity;
            }
            return finishCartModel;

        }

        public async Task DeleteProduct(long idCart, long idProduct)
        {
            await _repository.DeleteProduct(idCart, idProduct);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
